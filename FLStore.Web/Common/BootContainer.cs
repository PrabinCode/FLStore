using FLStore.Database.IServices;
using FLStore.Database.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace FLStore.Web.Common
{
    public class BootContainer
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<ILogin, LoginService>();
            container.RegisterType<ICommon, CommonService>();
            container.RegisterType<IProduct, ProductService>();
            return container;
        }
    }
}