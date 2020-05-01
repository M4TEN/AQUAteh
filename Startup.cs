using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using ShopGiacomini.Data.ApplicationContext;
using ShopGiacomini.Data.Infrastructure;
using ShopGiacomini.Data.Repositories;
using ShopGiacomini.Model;
using ShopGiacomini.Service;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Host.SystemWeb;
using ShopGiacomini.Data.Identity;
using ShopGiacomini.App_Start;

[assembly: OwinStartup(typeof(ShopGiacomini.Startup))]

namespace ShopGiacomini
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAutofac(app);
            IdentityStartup.ConfigureAuth(app);
        }

        public static void ConfigureAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();
            builder.RegisterType<ApplicationContext>().AsSelf().InstancePerRequest();

            builder.RegisterType<ApplicationUserStore>().As<IUserStore<User>>().InstancePerRequest();
            builder.RegisterType<ApplicationRoleStore>().As<IRoleStore<IdentityRole, string>>();
            builder.RegisterType<ApplicationRoleManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<EmailService>().As<IEmailService>().InstancePerRequest();
            builder.RegisterType<SmsService>().As<ISmsService>().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ProductRepository).Assembly).Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ProductService).Assembly).Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterFilterProvider();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
