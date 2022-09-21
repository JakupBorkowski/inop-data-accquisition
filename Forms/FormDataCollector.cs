using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Google.Protobuf.WellKnownTypes;


namespace USB_205_DataAccquisition.Forms
{
    public partial class FormDataCollector : Form
    {
        //aktualne kolory
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btns.BackColor = ThemeColor.PrimaryColor;
                    btns.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label1.ForeColor = ThemeColor.PrimaryColor;
        }


        //'definicja plytki zgodnie z numerem wykorzystanem w srodowisku Instacal'
        private MccDaq.MccBoard mydaqboard;

        //instancja klasy przechowujaca dane z wejsc/wyjsc urządzenia pomiarowego Measurement Computing USB-205
        USB205 usb205 = new USB205();

        //'liczba impulsów enkodera'

        //polozenie katowe na podstawie zliczonych impulsów 
        float CalculatedEncoderPosition;
        float tmpCalculatedEncoderPosition;

        //opis osi x
        double x;

        //plik do zapisywania
        StreamWriter write;
        DateTime myDateTime;
        //string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

        //max cisnienie variable
        
        //calculation
        double normalizedPressure;

        double[] pressureTab = new double[Globals.numberOfSamples];
        int itr = 0;
        int count;

        bool aboveOneM = false;

        int counterAfterRotation = 0;
        long countImpuls;

        bool afterFirstIteration = false;

        float lastReading;


        public FormDataCollector()
        {
            InitializeComponent();
            //LoadTheme();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Rozpocznij zapisywanie danych")
            {
                //Zczytanie daty rozpoczecia zapisu
                myDateTime = DateTime.Now;
                

                SaveFileDialog save = new SaveFileDialog();
                save.Title = "Save File";
                save.Filter = "Excel Files (*csv)|*csv| All Files (*.*)|*.*";


                if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    write = new StreamWriter(File.Create(save.FileName+".csv"));
                    write.Write("Cisnienie" + ";" + "Polozenie katowe" + ";"+ "Data      " + ";" + "Aktualna godzina" + ";" + "Krok probkowania \n");
                    btnSave.Text = "Zakończ zapisywanie danych";
                }
                
            }
            else if (btnSave.Text == "Zakończ zapisywanie danych")
            {
                btnSave.Text = "Rozpocznij zapisywanie danych";

                //zamkniecie pliku, do ktorego zapisywanie byly dane
                write.Dispose();
            }
        }

        private void FormDataCollector_Load(object sender, EventArgs e)
        {



            //timer1.Tick += timer1_Tick;
            //timer2.Tick += timer2_Tick;
            timer1.Interval = int.Parse(txtTs.Text.Trim());
            //button1.Text = "Start";

            timer1.Start();


            //button1.Text = "Stop";
            btnSave.Text = "Rozpocznij zapisywanie danych";
            

            //'Ustawienie liczby impulsów enkodera'
            Globals.numberOfEncoderImpulses = 10000;

            mydaqboard = new MccDaq.MccBoard(0);
            LoadTheme();

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //'odczytanie wartosci z wejscia CH0'
            mydaqboard.AIn(0, MccDaq.Range.Bip10Volts, out usb205.ValueOfAnalog0); //ValueOfAnalog0
            //'Konwertuje liczbę całkowitą na równoważną wartość napięcia (lub prądu) o pojedynczej precyzji'
            mydaqboard.ToEngUnits(MccDaq.Range.Bip10Volts, usb205.ValueOfAnalog0, out usb205.RealValueOfAnalog0);


            if (itr < Globals.numberOfSamples)
            {

                pressureTab[itr] = usb205.RealValueOfAnalog0;
                itr++;
            }
            else
            {
                itr = 0;
            }

            mydaqboard.CIn32(0, out count);

            // obliczone polozenie katowe enkodera
            int tmp = count % Globals.numberOfEncoderImpulses;
            //CalculatedEncoderPosition = (float) tmp/ NumberOfEncoderImpulses * 360;
            Console.WriteLine(CalculatedEncoderPosition);


            if (count > 1000000)
            {
                aboveOneM = true;
            }
            if (count < 1000000 && aboveOneM == true)
            {
                counterAfterRotation++;
                aboveOneM = false;
            }
            countImpuls = tmp + counterAfterRotation * 4294967295;
            CalculatedEncoderPosition = (float)countImpuls / Globals.numberOfEncoderImpulses * 360;

            if (Globals.usrednianieEnabled)
            {
                normalizedPressure = (Globals.maxPressure - Globals.minPressure) * ((pressureTab.Sum() / (pressureTab.Length)) - Globals.minReading) / (Globals.maxReading - Globals.minReading) + Globals.minPressure;
            }
            else
            {
                normalizedPressure = (Globals.maxPressure - Globals.minPressure) * (usb205.RealValueOfAnalog0 - Globals.minReading) / (Globals.maxReading - Globals.minReading) + Globals.minPressure;
            }
           
            //wyswietlanie tekstu w label2 i label3 dotyczącego aktualnego stanu  badanych wejść CHO i DIO0
            label2.Text = "CH0:  " + normalizedPressure;
            label3.Text = "DIO0: " + CalculatedEncoderPosition.ToString();
            label5.Text = count.ToString();
            //ustawianie zakresu dla primary Y axis
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 360;


            //ustawianie zakresu dla secondary Y axis
            chart1.ChartAreas[0].AxisY2.Minimum = Globals.minPressure;
            chart1.ChartAreas[0].AxisY2.Maximum = 110;

            //ustawianie nazwy dla primary osi Y
            chart1.ChartAreas[0].AxisY.Title = "Położenie kątowe";

            //ustawianie nazwy dla secondary osi Y
            chart1.ChartAreas[0].AxisY2.Title = "Ciśnienie";


            //rysowanie wykresu dla wejścia analogowego CH0
            chart1.Series[0].Points.AddXY(Math.Round(x, 2), normalizedPressure);

            //rysowanie wykresy dla wejscia cyfrowego DIO0-
            chart1.Series[1].Points.AddXY(Math.Round(x, 2), CalculatedEncoderPosition);


            //ta czesc odpowiada ze przesuwanie wykresu w prawo
            if (chart1.Series[0].Points.Count > 100)
                chart1.Series[0].Points.RemoveAt(0);

            chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
            chart1.ChartAreas[0].AxisX.Maximum = Math.Round(x,2);


            //aktualizacja osi x 
            //kolejne probki odczytywane są co 100ms, zgodnie z timer1.Interval
            //timer1.Interval może być zmieniony w zależności od preferencji użytkownika
            //trzeba jeszcze sprawdzić jaka jest predkość transmisji danych z urządzenia pomiarowego i 
            //na tej podstawie dobrac timer1.Interval
            x += (double)timer1.Interval / 1000;
            myDateTime = DateTime.Now;


            //Kazdorazowe zapisywanie do pliku tekstowego/csv jezeli WriteFlag jest aktywna, to znaczy jeżeli
            //wcisniety zostal przycisk zapisz do pliku tekstowego i wybrane zostalo docelowe miejsce zapisu danych
            if (btnSave.Text == "Zakończ zapisywanie danych")
            {
                write.Write(normalizedPressure.ToString() + ";" + CalculatedEncoderPosition.ToString() + ";" + myDateTime.ToString("yyyy-MM-dd") +";"+ myDateTime.ToString("HH:mm:ss.fff")+";" + Math.Round(x,2).ToString() + "\n");
                //label6.Text = normalizedPressure.ToString() + "   ;   " + tmpCalculatedEncoderPosition.ToString() + "   ;   " + myDateTime.ToString("yyyy-MM-dd") + "   ;   " + myDateTime.ToString("HH:mm:ss.fff") + "   ;   " + Math.Round(x, 2).ToString() + "\n";

            }
            lastReading = usb205.RealValueOfAnalog0;

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void txtTs_TextChanged(object sender, EventArgs e)
        {
            if (txtTs.Text != String.Empty)
            {
                timer1.Interval = int.Parse(txtTs.Text.Trim());
            }
            else
            {
                timer1.Interval = 500;
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            mydaqboard.CClear(0);

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }

}
