using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FLStore.Web.Models
{
    public class RegistrationModel
    {
        public string CustomerStatus { get; set; }
        [Display(Name = "User Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets allowed")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only Alphabets allowed")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets allowed")]
        public string LastName { get; set; }
        [Display(Name = "Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address is required")]
        public string CustomerAddress { get; set; }
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        public string CustomerEmail { get; set; }
        [Display(Name = "Mobile Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mobile Number is required")]
        [RegularExpression("^[9][0-9]*$", ErrorMessage = "Phone Number Start With 9")]
        [MaxLength(10, ErrorMessage = "Mobile Number Max Length is Invalid"), MinLength(10, ErrorMessage = "Mobile Number Minimum Length is Invalid")]
        public string CustomerMobileNo { get; set; }
        [Display(Name = "Fax")]
        public string CustomerFax { get; set; }
        [Display(Name = "Register As")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Register As is required")]
        public string CustomerType { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Company Address")]
        public string CompanyAddress { get; set; }
        [Display(Name = "Company Phone")]
        public string CompanyPhone { get; set; }
        [Display(Name = "Company Fax")]
        public string CompanyFax { get; set; }
        [Display(Name = "Prefered Shipment Method")]
        public string PreferedShipMethod { get; set; }
        [Display(Name = "School Name")]
        public string SchoolName { get; set; }
        [Display(Name = "Profile Image")]
        public string ProfileImage { get; set; }

        [Display(Name ="Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [RegularExpression(@"^.*(?=.{8,16})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$", ErrorMessage = "Must be 8 to 16 Length and must contain a-z,A-Z,0-9,@#$%^&+=")]
        public string UserPassword { get; set; }
        [Display(Name = "Confirm Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is required")]
        [Compare("UserPassword", ErrorMessage = "Confirm New Password doesn't match")]
        [RegularExpression(@"^.*(?=.{8,16})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$", ErrorMessage = "Must be 8 to 16 Length and must contain a-z,A-Z,0-9,@#$%^&+=")]
        public string ConfirmPassword { get; set; }
    }
}