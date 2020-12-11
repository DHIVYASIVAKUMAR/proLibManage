//using Microsoft.Owin;
//using Owin;

//[assembly: OwinStartupAttribute(typeof(proLibManageSys.Startup))]
//namespace proLibManageSys
//{
//    public partial class Startup
//    {
//        public void Configuration(IAppBuilder app)
//        {
//            ConfigureAuth(app);
//        }
//    }
////}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Options;
//using Microsoft.AspNetCore.Building;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.HttpsPolicy;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proLibManageSys.Startup))]
namespace proLibManageSys
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
