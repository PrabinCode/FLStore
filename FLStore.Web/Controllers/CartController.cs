using FLStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FLStore.Web.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult AddToCart(int productId, string url)
        //{
        //    if (Session["cart"] == null)
        //    {
        //        List<ItemModel> cart = new List<ItemModel>();
        //        var product = ctx.Tbl_Product.Find(productId);
        //        cart.Add(new ItemModel()
        //        {
        //            Product = product,
        //            Quantity = 1
        //        });
        //        Session["cart"] = cart;
        //    }
        //    else
        //    {
        //        List<ItemModel> cart = (List<ItemModel>)Session["cart"];
        //        var count = cart.Count();
        //        var product = ctx.Tbl_Product.Find(productId);
        //        for (int i = 0; i < count; i++)
        //        {
        //            if (cart[i].Product.ProductId == productId.ToString())
        //            {
        //                int prevQty = cart[i].Quantity;
        //                cart.Remove(cart[i]);
        //                cart.Add(new ItemModel()
        //                {
        //                    Product = product,
        //                    Quantity = prevQty + 1
        //                });
        //                break;
        //            }
        //            else
        //            {
        //                var prd = cart.Where(x => x.Product.ProductId == productId).SingleOrDefault();
        //                if (prd == null)
        //                {
        //                    cart.Add(new Item()
        //                    {
        //                        Product = product,
        //                        Quantity = 1
        //                    });
        //                }
        //            }
        //        }
        //        Session["cart"] = cart;
        //    }
        //    return Redirect(url);
        //}
        //public ActionResult RemoveFromCart(int productId)
        //{
        //    List<Item> cart = (List<Item>)Session["cart"];
        //    foreach (var item in cart)
        //    {
        //        if (item.Product.ProductId == productId)
        //        {
        //            cart.Remove(item);
        //            break;
        //        }
        //    }
        //    Session["cart"] = cart;
        //    return Redirect("Index");
        //}
    }
}