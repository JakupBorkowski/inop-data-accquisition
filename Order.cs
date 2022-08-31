using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USB_205_DataAccquisition
{
    internal class Order
    {
        public int id { get; set; }
        public string company { get; set; }
        public string nr_order { get; set; }
        public string FullName
        {
            get
            {
                return company + " - " + nr_order; 
            }
        }

        public Order(int id, string company, string nr_order)
        {
            this.id = id;
            this.company = company;
            this.nr_order = nr_order;
        }
        public Order(string company, string nr_order)
        {
            this.company = company;
            this.nr_order = nr_order;
        }
        public Order()
        {
           
        }


    }
}
