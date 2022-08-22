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

        //'rezerwowanie miejsca na wartosci odczytane z portów CH0-CH7'
        private short ValueOfAnalog0;
        private short ValueOfAnalog1;
        private short ValueOfAnalog2;
        private short ValueOfAnalog3;
        private short ValueOfAnalog4;
        private short ValueOfAnalog5;
        private short ValueOfAnalog6;
        private short ValueOfAnalog7;

        //'rezerwowanie miejsca na wartosci odczytane z portó CH0-CH7 zapisane w postaci rzeczywistej'
        private float RealValueOfAnalog0;
        private float RealValueOfAnalog1;
        private float RealValueOfAnalog2;
        private float RealValueOfAnalog3;
        private float RealValueOfAnalog4;
        private float RealValueOfAnalog5;
        private float RealValueOfAnalog6;
        private float RealValueOfAnalog7;

        //'rezerwowanie miejsca na odczytaną wartość z portu DIO0-DIO7'
        private short ValueOfAuxPort0;
        private short ValueOfAuxPort1;
        private short ValueOfAuxPort2;
        private short ValueOfAuxPort3;
        private short ValueOfAuxPort4;
        private short ValueOfAuxPort5;
        private short ValueOfAuxPort6;
        private short ValueOfAuxPort7;

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
        bool WriteFlag;
        bool IsSaveButtonClicked;

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Tick += timer1_Tick;
            timer1.Interval = 1;
            button1.Text = "Start";


            //ustawianie zakresu dla primary Y axis
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 360;


            //ustawianie zakresu dla secondary Y axis
            chart1.ChartAreas[0].AxisY2.Minimum = -10;
            chart1.ChartAreas[0].AxisY2.Maximum = 10;

            timer1.Start();
            button1.Text = "Stop";
            WriteFlag = false;
            IsSaveButtonClicked = false;
        }

        public Form1()
        {
            InitializeComponent();
            mydaqboard = new MccDaq.MccBoard(0);
            //'Ustawienie liczby impulsów enkodera'
            NumberOfEncoderImpulses = 1024;

            
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
            Device device = new Device("jakub");
            DbDevice.UpdateDevice(device,"3");
                
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //'odczytanie wartosci z wejscia CH0'
            mydaqboard.AIn(0, MccDaq.Range.Bip10Volts, out ValueOfAnalog0);
            //'Konwertuje liczbę całkowitą na równoważną wartość napięcia (lub prądu) o pojedynczej precyzji'
            mydaqboard.ToEngUnits(MccDaq.Range.Bip10Volts, ValueOfAnalog0, out RealValueOfAnalog0);


            //'ustawianie portu DIO0 jako port DIGITAL IN'
            mydaqboard.DConfigPort(MccDaq.DigitalPortType.AuxPort0, MccDaq.DigitalPortDirection.DigitalIn);
            //'odczytywanie wartości z portu DIO0'
            mydaqboard.DIn(MccDaq.DigitalPortType.AuxPort0,out ValueOfAuxPort0);


            //'obliczenie kąta enkodera na podstawie zliczonych impulsów'
            if(ValueOfAuxPort0 == 1)
            {
                CurrentNumberOfImpulses += 1;
            }

            if (CurrentNumberOfImpulses > NumberOfEncoderImpulses)
            {
                CurrentNumberOfImpulses = 0;
            }

            // obliczone polozenie katowe enkodera
            CalculatedEncoderPosition = (float)CurrentNumberOfImpulses/NumberOfEncoderImpulses * 360;


            //rysowanie wykresu dla wejścia analogowego CH0
            chart1.Series[0].Points.AddXY(x, RealValueOfAnalog0);

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
            if (WriteFlag)
            {
                write.Write(RealValueOfAnalog0.ToString()+","+CalculatedEncoderPosition.ToString()+"\n");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsSaveButtonClicked == false)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Title = "Save File";
                save.Filter = "Text Files (*txt)|*txt| All Files (*.*)|*.*";

                if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    write = new StreamWriter(File.Create(save.FileName));
                    WriteFlag = true;
                    write.Write("Położenie kątowe" + "," + "Ciśnienie" + "\n");
                }
                IsSaveButtonClicked = true;
                btnSave.Text = "Zakończ zapisywanie danych";
            }
            else
            {
                IsSaveButtonClicked=false;
                btnSave.Text = "Rozpocznij zapisywanie danych";
                WriteFlag = false;

                //zamkniecie pliku, do ktorego zapisywanie byly dane
                write.Dispose();
            }

        }
    }
}
