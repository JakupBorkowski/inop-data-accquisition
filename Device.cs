using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USB_205_DataAccquisition
{
    internal class Device
    {
        public int idDevice { get; }
        public string name { get; set; }

        public Device(string name)
        {
            this.name = name;
        }
    }
}
