using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USB_205_DataAccquisition
{
    internal class USB205
    {
        //'rezerwowanie miejsca na wartosci odczytane z portów CH0-CH7'
        public short ValueOfAnalog0;
        public short ValueOfAnalog1;
        public short ValueOfAnalog2;
        public short ValueOfAnalog3;
        public short ValueOfAnalog4;
        public short ValueOfAnalog5;
        public short ValueOfAnalog6;
        public short ValueOfAnalog7;

        //'rezerwowanie miejsca na wartosci odczytane z portó CH0-CH7 zapisane w postaci rzeczywistej'
        public float RealValueOfAnalog0;
        public float RealValueOfAnalog1;
        public float RealValueOfAnalog2;
        public float RealValueOfAnalog3;
        public float RealValueOfAnalog4;
        public float RealValueOfAnalog5;
        public float RealValueOfAnalog6;
        public float RealValueOfAnalog7;

        //'rezerwowanie miejsca na odczytaną wartość z portu DIO0-DIO7'
        public short ValueOfAuxPort0;
        public short ValueOfAuxPort1;
        public short ValueOfAuxPort2;
        public short ValueOfAuxPort3;
        public short ValueOfAuxPort4;
        public short ValueOfAuxPort5;
        public short ValueOfAuxPort6;
        public short ValueOfAuxPort7;



    }
}
