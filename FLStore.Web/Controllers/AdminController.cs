using FLStore.Database.IServices;
using FLStore.Shared;
using FLStore.Web.Common;
using FLStore.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace FLStore.Web.Controllers
{
    public class AdminController : Controller
    {
        ICommon _common;
        IProduct _product;
        public AdminController(ICommon common, IProduct product)
        {
            _common = common;
            _product = product;
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Categories()
        {
            var categories = _common.Dropdown("ProductCategory");

            return View();
        }

        public ActionResult Product()
        {
            List<ProductCommon> productList = _product.ProductList();
            List<ProductModel> model = new List<ProductModel>();
            model = productList.MapObjects<ProductModel>();

            return View(model);
        }
        public ActionResult ProductEdit(string productId)
        {
            LoadDropDownList();
            var decProductId = productId.DecryptParameter();
            if (string.IsNullOrEmpty(decProductId))
            {
                return RedirectToAction("Product");
            }
            ProductCommon common = new ProductCommon();
            common.ProductId = decProductId;
            var resp = _product.GetProduct(common);
            ProductModel model = new ProductModel();
            model = resp.MapObject<ProductModel>();
            model.ProductId = model.ProductId.EncryptParameter();
            return View(model);
        }
        [HttpPost]
        public ActionResult ProductEdit(ProductModel model, HttpPostedFileBase file)
        {
            LoadDropDownList();

            var filePath = "";
            var FileLocation = "/Content/Images/Furniture/";
            #region "file"
            if (file != null)
            {
                var allowedExtensions = new[] { ".jpg", ".png", ".jpeg" };
                var fileName = Path.GetFileName(file.FileName);
                String timeStamp = DateTime.Now.ToString();
                var ext = Path.GetExtension(file.FileName);
                if (file.ContentLength > 1 * 1024 * 1024)//1 MB
                {
                    return View(model);
                }
                if (allowedExtensions.Contains(ext.ToLower()))
                {
                    string datet = timeStamp.Replace('/', '_').Replace(':', '_');
                    string myfilename = model.CategoryId + "_product" + datet + ext;
                    filePath = Path.Combine(Server.MapPath(FileLocation), myfilename);
                    model.ProductImage = FileLocation + myfilename;
                    //PPImageFile.SaveAs(PPImagePath);
                }
                else
                {
                    return View(model);
                }
            }
            #endregion
            if (ModelState.IsValid)
            {
                try
                {
                    ProductCommon common = new ProductCommon();
                    common = model.MapObject<ProductCommon>();
                    var decProductId = model.ProductId.DecryptParameter();
                    if (string.IsNullOrEmpty(decProductId))
                    {
                        return RedirectToAction("Product");
                    }
                    common.ProductId = decProductId;
                    var dbres = _product.ManageProduct(common);
                    int code = (int)dbres.Code;
                    //TempData["msg"] = dbres.Message;
                    if (dbres.Code == ResponseCode.Success)
                    {
                        TempData["msg"] = dbres.Message ?? "Product added Successfully! ";
                        if (filePath != "")
                            file.SaveAs(filePath);
                        return RedirectToAction("Product", "Admin");
                    }
                    else
                    {
                        TempData["message"] = dbres.Message ?? "Something Went Wrong";
                        return View(model);
                    }
                }
                catch (Exception ex)
                {
                    TempData["message"] = "Something Went Wrong";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
            return RedirectToAction("Product");
        }
        public ActionResult ProductAdd()
        {
            LoadDropDownList();
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(ProductModel model, HttpPostedFileBase file)
        {
            LoadDropDownList();

            var filePath = "";
            var FileLocation = "/Content/Images/Furniture/";
            #region "file"
            if (file != null)
            {
                var allowedExtensions = new[] { ".jpg", ".png", ".jpeg" };
                var fileName = Path.GetFileName(file.FileName);
                String timeStamp = DateTime.Now.ToString();
                var ext = Path.GetExtension(file.FileName);
                if (file.ContentLength > 1 * 1024 * 1024)//1 MB
                {
                    return View(model);
                }
                if (allowedExtensions.Contains(ext.ToLower()))
                {
                    string datet = timeStamp.Replace('/', '_').Replace(':', '_');
                    string myfilename = model.CategoryId + "_product" + datet + ext;
                    filePath = Path.Combine(Server.MapPath(FileLocation), myfilename);
                    model.ProductImage = FileLocation + myfilename;
                    //PPImageFile.SaveAs(PPImagePath);
                }
                else
                {
                    return View(model);
                }
            }
            #endregion
            if (ModelState.IsValid)
            {
                try
                {
                    ProductCommon common = new ProductCommon();
                    common = model.MapObject<ProductCommon>();

                    var dbres = _product.ManageProduct(common);
                    int code = (int)dbres.Code;
                    //TempData["msg"] = dbres.Message;
                    if (dbres.Code == ResponseCode.Success)
                    {
                        TempData["msg"] = dbres.Message ?? "Product added Successfully! ";
                        if (filePath != "")
                            file.SaveAs(filePath);
                        return RedirectToAction("Product", "Admin");
                    }
                    else
                    {
                        TempData["message"] = dbres.Message ?? "Something Went Wrong";
                        return View(model);
                    }
                }
                catch (Exception ex)
                {
                    TempData["message"] = "Something Went Wrong";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
            return RedirectToAction("Product");
        }

        public void LoadDropDownList(string productCategory = "")
        {
            ViewBag.CategoryList = ApplicationUtilities.SetDDLValue(LoadDropdownList("ProductCategory") as Dictionary<string, string>, productCategory, "Select Product Category");
            ViewBag.ProductStatusList = ApplicationUtilities.SetDDLValue(LoadDropdownList("ProductStatus") as Dictionary<string, string>, productCategory, "Select Product Status");
        }
        public object LoadDropdownList(string flag, string search1 = "")
        {
            switch (flag)
            {

                case "ProductCategory":
                    return _common.Dropdown("prod_cat");
                case "ProductStatus":
                    {
                        Dictionary<string, string> dict = new Dictionary<string, string>();
                        dict.Add("A", "ACTIVE");
                        dict.Add("B", "BLOCKED");
                        return dict;
                    };
            }
            return null;
        }
    }
}