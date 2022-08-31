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
        public string nr_order{ get; set; }
        public string name { get; set; }    
        public string start { get; set; }
        public int numberOfSamples { get; set; }
        public double tp { get; set; }

        public Session(string nr_order, string name, string start, int numberOfSamples, double tp)
        {
            this.nr_order = nr_order;   
            this.name = name;
            this.start = start;
            this.numberOfSamples = numberOfSamples;
            this.tp = tp;
        }
    }
}
