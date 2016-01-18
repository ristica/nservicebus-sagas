using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Nsb.Infrastructure;

namespace Nsb.Client
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ServiceBus.Initialize("Nsb.Client");

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
