using FLStore.Web.Common;
using System.Web;
using System.Web.Mvc;

namespace FLStore.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new SessionExpiryFilterAttribute());
        }
    }
}
