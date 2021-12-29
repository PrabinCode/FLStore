using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FLStore.Shared;

namespace FLStore.Database.IServices
{
    public interface ILogin
    {
        LoginResponse UserLogin(LoginCommon request);
        CommonDbResponse Signup(CustomerCommon customer);

    }
}
