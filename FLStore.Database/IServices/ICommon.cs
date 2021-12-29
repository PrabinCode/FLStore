using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FLStore.Shared;

namespace FLStore.Database.IServices
{
    public interface ICommon
    {
        Dictionary<string, string> Dropdown(string flag, string search1 = "");

    }
}
