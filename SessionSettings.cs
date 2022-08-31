using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USB_205_DataAccquisition
{
    internal class SessionSettings
    {
        public int id { get; }
        public string nr_order { get; set; }
        public string name { get; set; }
        public int number_of_samples { get; set; }
        public double tp { get; set; }

        public SessionSettings(string nr_order, string name, int number_of_samples, double tp)
        {
            this.nr_order = nr_order;
            this.name = name;
            this.number_of_samples = number_of_samples;
            this.tp = tp;
        }

        public SessionSettings()
        {

        }

    }
}
