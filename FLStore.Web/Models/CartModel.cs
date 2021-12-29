using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLStore.Web.Models
{
    public class CartModel
    {
        public string CartId { get; set; }
        public string ProductId { get; set; }
        public string CustomerId { get; set; }
        public string CartStatusId { get; set; }
    }
    public class CartStatusModel 
    {
        public string CartStatusId { get; set; }
        public string Status { get; set; }
    }
    public class ItemModel
    {
        public ProductModel Product { get; set; }
        public int Quantity { get; set; }
    }
}