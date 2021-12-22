using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLStore.Shared
{
    public class ShippingDetailCommon:Common
    {
        public string ShippingDetailId { get; set; }
        public string CustomerId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string OrderId { get; set; }
        public string AmountPaid { get; set; }
        public string PaymentType { get; set; }
    }
}
