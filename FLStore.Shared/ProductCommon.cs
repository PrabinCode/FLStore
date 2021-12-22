using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLStore.Shared
{
    public class ProductCommon : Common
    {
        public string ProductId { get; set; }
        public string ProductName{ get; set; }
        public string CategoryId{ get; set; }
        public string ProductStatus{ get; set; }
        public string IsDeleted{ get; set; }
        public string ProductDescription{ get; set; }
        public string ProductImage{ get; set; }
        public string AvailableQuantity{ get; set; }
        public string AvailabelColor{ get; set; }
        public string IsFeatured{ get; set; }
        public string ProductSize{ get; set; }
        public string ProductWeight{ get; set; }
        public string ProductPrice{ get; set; }
        public string ProductShipTime{ get; set; }
    }
}
