using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USB_205_DataAccquisition
{
    internal class Sample
    {
        public int idSample { get; }
        public int idChannel { get; set; }
        public float value { get; set; }
        public string timestamp { get; set; }

        public Sample(int idChannel, float value, string timestamp)
        {
            this.idChannel = idChannel;
            this.value = value;
            this.timestamp = timestamp;
        }
    }
}
