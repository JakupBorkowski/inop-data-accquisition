using MindFusion.Charting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MindFusion.Charting.Components;
using MindFusion.Charting.WinForms;
using System.IO;

namespace USB_205_DataAccquisition
{

    public partial class Form1 : Form
    {
        //'definicja plytki zgodnie z numerem wykorzystanem w srodowisku Instacal'
        private MccDaq.MccBoard mydaqboard;

        //instancja klasy przechowujaca dane z wejsc/wyjsc urządzenia pomiarowego Measurement Computing USB-205
        USB205 usb205 = new USB205();

        //'liczba impulsów enkodera'
        private int NumberOfEncoderImpulses;

        //'aktualna liczba zliczonych impulsów'
        private int CurrentNumberOfImpulses=0;

        //polozenie katowe na podstawie zliczonych impulsów 
        private float CalculatedEncoderPosition;

        //opis osi x
        double x;

        //plik do zapisywania
        StreamWriter write;

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Tick += timer1_Tick;
            timer1.Interval = 1;
            //button1.Text = "Start";

            timer1.Start();
            button1.Text = "Stop";
            btnSave.Text = "Rozpocznij zapisywanie danych";
            //ustawianie tekstu dla przycisku o id button2
            button2.Text = "Wyslij probki do bazy danych";

            //'Ustawienie liczby impulsów enkodera'
            NumberOfEncoderImpulses = 1024;

            mydaqboard = new MccDaq.MccBoard(0);
        }

        public Form1()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                button1.Text = "Start";
            }
                
            else
            {
                timer1.Start();
                button1.Text = "Stop";
            }
            
                
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //'odczytanie wartosci z wejscia CH0'
            mydaqboard.AIn(0, MccDaq.Range.Bip10Volts, out usb205.ValueOfAnalog0); //ValueOfAnalog0
            //'Konwertuje liczbę całkowitą na równoważną wartość napięcia (lub prądu) o pojedynczej precyzji'
            mydaqboard.ToEngUnits(MccDaq.Range.Bip10Volts, usb205.ValueOfAnalog0, out usb205.RealValueOfAnalog0);


            //'ustawianie portu DIO0 jako port DIGITAL IN'
            mydaqboard.DConfigPort(MccDaq.DigitalPortType.AuxPort0, MccDaq.DigitalPortDirection.DigitalIn);
            //'odczytywanie wartości z portu DIO0'
            mydaqboard.DIn(MccDaq.DigitalPortType.AuxPort0,out usb205.ValueOfAuxPort0);


            //'obliczenie kąta enkodera na podstawie zliczonych impulsów'
            if(usb205.ValueOfAuxPort0 == 1)
            {
                CurrentNumberOfImpulses += 1;
            }

            if (CurrentNumberOfImpulses > NumberOfEncoderImpulses)
            {
                CurrentNumberOfImpulses = 0;
            }

            // obliczone polozenie katowe enkodera
            CalculatedEncoderPosition = (float)CurrentNumberOfImpulses/NumberOfEncoderImpulses * 360;
            Console.WriteLine(usb205.ValueOfAuxPort0.ToString());

            //rysowanie wykresu dla wejścia analogowego CH0
            chart1.Series[0].Points.AddXY(x, usb205.RealValueOfAnalog0);

            //rysowanie wykresy dla wejscia cyfrowego DIO0-
            chart1.Series[1].Points.AddXY(x, CalculatedEncoderPosition);


            //ta czesc odpowiada ze przesuwanie wykresu w prawo
            if (chart1.Series[0].Points.Count > 100)
                chart1.Series[0].Points.RemoveAt(0);

            chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
            chart1.ChartAreas[0].AxisX.Maximum = x;


            //ustawianie zakresu dla primary Y axis
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 360;


            //ustawianie zakresu dla secondary Y axis
            chart1.ChartAreas[0].AxisY2.Minimum = -10;
            chart1.ChartAreas[0].AxisY2.Maximum = 10;

            //ustawianie nazwy dla primary osi Y
            chart1.ChartAreas[0].AxisY.Title = "Położenie kątowe";  

            //ustawianie nazwy dla secondary osi Y
            chart1.ChartAreas[0].AxisY2.Title = "Ciśnienie";

            


            //aktualizacja osi x 
            //kolejne probki odczytywane są co 100ms, zgodnie z timer1.Interval
            //timer1.Interval może być zmieniony w zależności od preferencji użytkownika
            //trzeba jeszcze sprawdzić jaka jest predkość transmisji danych z urządzenia pomiarowego i 
            //na tej podstawie dobrac timer1.Interval
            x += (double)timer1.Interval/1000;



            //Kazdorazowe zapisywanie do pliku tekstowego/csv jezeli WriteFlag jest aktywna, to znaczy jeżeli
            //wcisniety zostal przycisk zapisz do pliku tekstowego i wybrane zostalo docelowe miejsce zapisu danych
            if (btnSave.Text == "Zakończ zapisywanie danych")
            {
                write.Write(usb205.RealValueOfAnalog0.ToString()+","+CalculatedEncoderPosition.ToString()+"\n");
            }


            if (button2.Text == "Zakoncz wysylanie probek do bazy danych")
            {
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                //Dodawanie probek z dwoch kanalów (CHO oraz DIO0 do bazy danych do tabeli sample)
                Sample sampleCH0 = new Sample(1, (float)usb205.RealValueOfAnalog0, sqlFormattedDate);
                Sample sampleDIO0 = new Sample(9, (float)CalculatedEncoderPosition, sqlFormattedDate);
                DbSample.AddSample(sampleCH0);
                DbSample.AddSample(sampleDIO0);
            }


            //wyswietlanie tekstu w label2 i label3 dotyczącego aktualnego stanu  badanych wejść CHO i DIO0
            label2.Text = "CH0:  " + usb205.RealValueOfAnalog0.ToString();
            label3.Text = "DIO0: " + CalculatedEncoderPosition.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Rozpocznij zapisywanie danych")
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Title = "Save File";
                save.Filter = "Text Files (*txt)|*txt| All Files (*.*)|*.*";

                if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    write = new StreamWriter(File.Create(save.FileName));
                    write.Write("Położenie kątowe" + "," + "Ciśnienie" + "\n");
                }
                btnSave.Text = "Zakończ zapisywanie danych";
            }
            else if(btnSave.Text == "Zakończ zapisywanie danych")
            {
                btnSave.Text = "Rozpocznij zapisywanie danych";
               
                //zamkniecie pliku, do ktorego zapisywanie byly dane
                write.Dispose();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Wyslij probki do bazy danych")
            {
                button2.Text = "Zakoncz wysylanie probek do bazy danych";

                //odczyta aktualnego czasu w formacie "yyyy-MM-dd HH:mm:ss.fff"
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                //utworzenie nowej sesji
                Session session = new Session("nowa", sqlFormattedDate, 1, (float)1.2);
                DbSession.AddSession(session);

                //TU jeszcze do przemyslenia (mozna zapisywac kilka wejs jako tabele json, to bedzie to bardziej logiczne).
                DbSessionhaschannel.AddSessionhaschannel(DbSession.LastSessionId(), 1);
                DbSessionhaschannel.AddSessionhaschannel(DbSession.LastSessionId(), 9);

            }
            else if(button2.Text == "Zakoncz wysylanie probek do bazy danych")
            {
                button2.Text = "Wyslij probki do bazy danych";
            }
            
        }
    }
}
