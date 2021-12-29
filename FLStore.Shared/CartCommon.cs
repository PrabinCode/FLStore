using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLStore.Shared
{
    public class CartCommon : Common
    {
        public string CartId { get; set; }
        public string ProductId { get; set; }
        public string CustomerId { get; set; }
        public string CartStatusId { get; set; }
    }
    public class CartStatus : Common
    {
        public string CartStatusId { get; set; }
        public string Status { get; set; }
    }
    public class ItemCommon : Common
    {
        public ProductCommon Product { get; set; }
        public int Quantity { get; set; }
    }
}
