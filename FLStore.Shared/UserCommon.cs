using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLStore.Shared
{
    public class UserCommon :Common
    {
        public string UserId { get; set; }
        public string UserRole { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserStatus { get; set; }
        public string IsBlocked { get; set; }
        public string UserRoleType { get; set; }
    }
}
