using System;
using System.Collections.Generic;
using System.Text;

namespace BE.DAL.DO.Objetos
{
    public partial class CustomerDemographics
    {
        public CustomerDemographics()
        {
            //CustomerCustomerDemo = new HashSet<CustomerCustomerDemo>();
        }

        public string CustomerTypeId { get; set; }
        public string CustomerDesc { get; set; }

        //public virtual ICollection<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
    }
}
