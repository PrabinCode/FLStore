using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FLStore.Web.Models
{
    public class ProductModel
    {
        [Display(Name = "Product Id")]
        public string ProductId { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Category")]
        public string CategoryId { get; set; }
        [Display(Name = "Product Status")]
        public string ProductStatus { get; set; }
        [Display(Name = "Is Deleted")]
        public string IsDeleted { get; set; }
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }
        [Display(Name = "Product Image")]
        public string ProductImage { get; set; }
        [Display(Name = "Available Quantity")]
        public string AvailableQuantity { get; set; }
        [Display(Name = "Availabel Color")]
        public string AvailabelColor { get; set; }
        [Display(Name = "Is Featured")]
        public string IsFeatured { get; set; }
        [Display(Name = "Product Size")]
        public string ProductSize { get; set; }
        [Display(Name = "Product Weight")]
        public string ProductWeight { get; set; }
        [Display(Name = "Product Price")]
        public string ProductPrice { get; set; }
        [Display(Name = "Product Ship Time")]
        public string ProductShipTime { get; set; }
    }
}