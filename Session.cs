using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USB_205_DataAccquisition
{
    internal class Session
    {
        public int idSession { get; }
        public int order_id { get; set; }
        public string name { get; set; }    
        public string start { get; set; }
        public int numberOfSamples { get; set; }
        public float tp { get; set; }

        public Session(int order_id, string name, string start, int numberOfSamples, float tp)
        {
            this.order_id = order_id;   
            this.name = name;
            this.start = start;
            this.numberOfSamples = numberOfSamples;
            this.tp = tp;
        }
    }
}
