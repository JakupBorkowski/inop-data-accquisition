using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USB_205_DataAccquisition
{
    internal class Event
    {
        public int idEvent { get; }
        public int idSession { get; set; }
        public int idMachine { get; set; }
        public string info { get;set; }
        public string stopTime { get; set; }
        public double stopTimeLength { get; set; }

        public Event(int idSession, int idMachine, string info, string stopTime, double stopTimeLength)
        {
            this.idSession = idSession;
            this.idMachine = idMachine;
            this.info = info;
            this.stopTime = stopTime;
            this.stopTimeLength = stopTimeLength;
        }
    }
}
