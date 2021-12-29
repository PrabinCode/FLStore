using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLStore.Shared
{
    public class LoginCommon
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool RememberMe { get; set; }
        public string IpAddress { get; set; }
        public string BrowserDetail { get; set; }
        public string Session { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Gender { get; set; }
        public bool IsEmailVerified { get; set; }
    }
    public class LoginResponse
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
