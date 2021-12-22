using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FLStore.Shared
{
    public class CustomerCommon : Common
    {
        public int CustomerId { get; set; }
        public string CustomerStatus { get; set; }
        public string UserName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerMobileNo { get; set; }
        public string CustomerFax { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyFax { get; set; }
        public string PreferedShipMethod { get; set; }
        public string SchoolName { get; set; }
        public string ProfileImage { get; set; }
    }
}
