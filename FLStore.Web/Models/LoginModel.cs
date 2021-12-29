using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FLStore.Web.Models
{
    public class LoginModel
    {
        [DisplayName("User Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Id/ Mobile Number is required")]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        //[RegularExpression(@"^.*(?=.{8,16})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$", ErrorMessage = "Must be 8 to 16 Length and must contain a-z,A-Z,0-9,@#$%^&+=")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Confirm New Password doesn't match")]
        [RegularExpression(@"^.*(?=.{8,16})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$", ErrorMessage = "Must be 8 to 16 Length and must contain a-z,A-Z,0-9,@#$%^&+=")]
        public string ConfirmPassword { get; set; }
        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
        public string IpAddress { get; set; }
        public string BrowserDetail { get; set; }
        public string Session { get; set; }
        public string FullName { get; set; }

        [EmailAddress(ErrorMessage = "Email is Invalid")]
        //[RegularExpression(@"^([\w-\+.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        //[RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid Mobile Number.")]
        [RegularExpression(@"^((980)|(981)|(982)|(984)|(985)|(986)|(974)|(976)|(975)|(988)|(961)|(962)|(972))([0-9]{7})$", ErrorMessage = "Mobile Number Not Valid")]
        //[RegularExpression(@"^([9]{1})([678]{1})([012]{1})([0-9]{7})$", ErrorMessage = "Mobile Number Not Valid")]
        public string MobileNo { get; set; }
        public string Gender { get; set; }
        public bool IsEmailVerified { get; set; }
    }
    public class LoginResponseModel
    {
        public string code { get; set; }
        public string message { get; set; }
        public string CustomerId { get; set; }
        public string UserName { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string FullName { get; set; }
        public string UserType { get; set; }
        public string Image { get; set; }
    }
}