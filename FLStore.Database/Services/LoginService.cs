using FLStore.Database.IServices;
using FLStore.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLStore.Database.Services
{
    public class LoginService : ILogin
    {
        DAOCommon DAO;
        public LoginService()
        {
            DAO = new DAOCommon();
        }

        public CommonDbResponse Signup(CustomerCommon customer)
        {
            string sql = "EXEC sproc_registration ";
            sql += " @flag='i'";
            sql += ",@UserName=" + DAO.FilterString(customer.UserName);
            sql += ",@FirstName=" + DAO.FilterString(customer.FirstName);
            sql += ",@MiddleName=" + DAO.FilterString(customer.MiddleName);
            sql += ",@LastName=" + DAO.FilterString(customer.LastName);
            sql += ",@CustomerAddress=" + DAO.FilterString(customer.CustomerAddress);
            sql += ",@CustomerEmail=" + DAO.FilterString(customer.CustomerEmail);
            sql += ",@CustomerMobileNo=" + DAO.FilterString(customer.CustomerMobileNo);
            sql += ",@CustomerFax=" + DAO.FilterString(customer.CustomerFax);
            sql += ",@CompanyName=" + DAO.FilterString(customer.CompanyName);
            sql += ",@CompanyAddress=" + DAO.FilterString(customer.CompanyAddress);
            sql += ",@CompanyPhone=" + DAO.FilterString(customer.CompanyPhone);
            sql += ",@CompanyFax=" + DAO.FilterString(customer.CompanyFax);
            sql += ",@PreferedShipMethod=" + DAO.FilterString(customer.PreferedShipMethod);
            sql += ",@SchoolName=" + DAO.FilterString(customer.SchoolName);
            sql += ",@ProfileImage=" + DAO.FilterString(customer.ProfileImage);
            sql += ",@UserPassword=" + DAO.FilterParameter(customer.UserPassword);
           
            CommonDbResponse dbresp = DAO.ParseCommonDbResponse(sql);
            return dbresp;
        }

        public LoginResponse UserLogin(LoginCommon request)
        {
            string sql = "EXEC sproc_user_login ";
            sql += " @flag='login'";
            sql += ",@user_name=" + DAO.FilterString(request.UserName);
            sql += ", @password=" + DAO.FilterParameter(request.Password);
            sql += ", @browser_info=" + DAO.FilterString(request.BrowserDetail);
            sql += ", @session_id=" + DAO.FilterString(request.Session);

            var dt = DAO.ExecuteDataTable(sql);
            LoginResponse resp = new LoginResponse();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow rows in dt.Rows)
                {
                    resp.code = rows["code"].ToString();
                    resp.message = rows["message"].ToString();
                    if (resp.code != "0")
                    {
                        break;
                    }
                    resp.CustomerId = rows["UserId"].ToString();
                    resp.RoleId = rows["RoleId"].ToString();
                    resp.UserName = rows["UserName"].ToString();
                    resp.FullName = rows["FullName"].ToString();
                    resp.UserType = rows["UserType"].ToString();
                    resp.RoleName = rows["RoleName"].ToString();
                    resp.Image = rows["ProfileImage"].ToString();
                }
            }
            else
            {
                resp.code = "1";
                resp.message = "Login Failed!";
            }
            return resp;
        }
    }
}
