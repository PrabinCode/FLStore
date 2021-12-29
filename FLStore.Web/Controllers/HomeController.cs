using Microsoft.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FLStore.Database.IServices;
using FLStore.Database.Services;
using System.Data.Entity;
using System.Threading.Tasks;
using FLStore.Web.Models;
using FLStore.Web.Common;
using System.Web.UI.WebControls;
using FLStore.Shared;
using System.Security.Cryptography;
using System.IO;

namespace FLStore.Web.Controllers
{
    public class HomeController : Controller
    {
        ILogin _login;
        ICommon _common;
        public HomeController(ILogin login, ICommon common)
        {
            _login = login;
            _common = common;
        }
        [OverrideActionFilters]
        public ActionResult Index()
        {
            if(ApplicationUtilities.GetSessionValue("UserType").ToString() == "ADMIN")
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            return View();
        }

        public ActionResult Manage()
        {
            return View();
        }
        [OverrideActionFilters]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [OverrideActionFilters]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        #region Login 
        [OverrideActionFilters]
        public ActionResult Login()
        {
            if (Session["UserName"] == null)
            {
                return View();
            }
            if (Session["UserType"].ToString().ToUpper() == "CUSTOMER")
                return RedirectToAction("Index", "Home");

            return RedirectToAction("LogOff");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OverrideActionFilters]
        public ActionResult Login(LoginModel loginModel)
        {
            string userName = loginModel.UserName ?? string.Empty;
            string passWord = loginModel.Password.EncryptPassword() ?? string.Empty;
            if ((string.IsNullOrEmpty(userName)) || (string.IsNullOrEmpty(passWord)))
            {
                ViewBag.ErrorMessage = "Invalid Details!";
                return View();
            }
            LoginCommon loginCommon = new LoginCommon();
            loginCommon = loginModel.MapObject<LoginCommon>();
            try
            {
                loginCommon.Password = passWord;
                LoginResponseModel dbres = _login.UserLogin(loginCommon).MapObject<LoginResponseModel>();
                if (dbres == null || dbres.code != "0")
                {
                    ViewBag.ErrorMessage = dbres.message ?? "Invalid Details!";
                    return View();
                }
                else
                {
                    var sGuid = Session.SessionID;
                    Session["SessionGuid"] = sGuid;
                    Session["UserId"] = dbres.CustomerId;
                    Session["RoleId"] = dbres.RoleId;
                    Session["RoleName"] = dbres.RoleName;
                    Session["UserType"] = dbres.UserType;
                    Session["Image"] = dbres.Image;
                    Session["UserName"] = dbres.UserName;
                    Session["FullName"] = dbres.FullName;

                    return RedirectToAction("Index", "Home");

                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Something Went Wrong";
                return View();
            }

        }
        #endregion

        #region Log Out
        [OverrideActionFilters]
        public ActionResult Logout()
        {
            AbandonSession();
            return RedirectToAction("Index", "Home");
        }
        public void AbandonSession()
        {
            HttpContext.Session.Clear();
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
            }
        }
        #endregion

        #region Registration
        [OverrideActionFilters]
        public ActionResult Registration()
        {
            if (Session["UserName"] == null)
            {
                RegistrationModel model = new RegistrationModel();
                LoadDropDownList(model);
                return View();
            }
            if (Session["UserType"].ToString().ToUpper() == "CUSTOMER")
                return RedirectToAction("Index", "Home");

            return RedirectToAction("LogOff");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OverrideActionFilters]

        public ActionResult Registration(RegistrationModel model, HttpPostedFileBase PPImageFile)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                               .Select(x => new { x.Key, x.Value.Errors }).ToArray();
            if (ModelState.IsValid)
            {
                try
                {
                    string userName = model.UserName ?? string.Empty;
                    string passWord = model.UserPassword.EncryptPassword() ?? string.Empty;
                    var PPImagePath = "";
                    var FileLocation = "/Content/Images/UserUpload/Profile/";
                    #region "PPImage"
                    if (PPImageFile != null)
                    {
                        var allowedExtensions = new[] { ".jpg", ".png", ".jpeg" };
                        var fileName = Path.GetFileName(PPImageFile.FileName);
                        String timeStamp = DateTime.Now.ToString();
                        var ext = Path.GetExtension(PPImageFile.FileName);
                        if (PPImageFile.ContentLength > 1 * 1024 * 1024)//1 MB
                        {
                            return View(model);
                        }
                        if (allowedExtensions.Contains(ext.ToLower()))
                        {
                            string datet = timeStamp.Replace('/', '_').Replace(':', '_');
                            string myfilename = model.CustomerMobileNo + "_PPImage_" + datet + ext;
                            PPImagePath = Path.Combine(Server.MapPath(FileLocation), myfilename);
                            model.ProfileImage = FileLocation + myfilename;
                            //PPImageFile.SaveAs(PPImagePath);
                        }
                        else
                        {
                            return View(model);
                        }
                    }
                    #endregion


                    CustomerCommon common = new CustomerCommon();
                    common = model.MapObject<CustomerCommon>();
                    common.UserPassword = passWord;
                    var dbres = _login.Signup(common);
                    int code = (int)dbres.Code;
                    //TempData["msg"] = dbres.Message;
                    if (dbres.Code == ResponseCode.Success)
                    {
                        TempData["msg"] = dbres.Message ?? "Registration Successful! Please login to get started!";
                        if (PPImagePath != "")
                            PPImageFile.SaveAs(PPImagePath);
                        return RedirectToAction("Login", "Home");
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
            return View(model);

        }

        #endregion

        public void LoadDropDownList(RegistrationModel model)
        {
            ViewBag.CustomerTypeList = ApplicationUtilities.SetDDLValue(LoadDropdownList("CustomerType") as Dictionary<string, string>, model.CustomerType, "Select Register As");
            ViewBag.ShipmentMethodList = ApplicationUtilities.SetDDLValue(LoadDropdownList("ShipmentMethod") as Dictionary<string, string>, model.PreferedShipMethod, "Select Prefered Shipment Method");
        }
        public object LoadDropdownList(string flag, string search1 = "")
        {
            switch (flag)
            {

                case "CustomerType":
                    return _common.Dropdown("cust_type");
                case "ShipmentMethod":
                    return _common.Dropdown("shipment");
                    //{
                    //    Dictionary<string, string> dict = new Dictionary<string, string>();
                    //    dict.Add("CORPORATE", "CORPORATE");
                    //    dict.Add("STUDENT", "STUDENT");
                    //    dict.Add("HOME", "HOME");
                    //    return dict;
                    //};
            }
            return null;
        }
    }
}