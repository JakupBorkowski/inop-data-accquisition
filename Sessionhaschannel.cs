using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USB_205_DataAccquisition
{
    internal class Sessionhaschannel
    {
        public int id { get; }
        public int idSession { get; set; }  
        public int idChannel { get; set; }

        public Sessionhaschannel(int idSession, int idChannel)
        {
            this.idSession = idSession;
            this.idChannel = idChannel;
        }
    }
}
