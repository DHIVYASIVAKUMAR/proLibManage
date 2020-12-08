using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
//using proLibManageSys.Data;
using proLibService.Context;
using Test.Context;

namespace proLibService
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			System.Data.Entity.Database.SetInitializer(new DatabaseInitializer());
			//System.Data.Entity.Database.SetInitializer(new DummyData());
		}
	}
}
/*
 using System.Web.Http;  
using Test.Context;  
   
namespace Test  
{  
    public class WebApiApplication : System.Web.HttpApplication  
    {  
        protected void Application_Start()  
        {  
            GlobalConfiguration.Configure(WebApiConfig.Register);  
            System.Data.Entity.Database.SetInitializer(new DatabaseInitializer());  
        }  
    }  
}
 */