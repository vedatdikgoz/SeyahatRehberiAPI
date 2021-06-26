using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using SeyahatRehberi.Business.Abstract;
using SeyahatRehberi.Business.Concrete;
using SeyahatRehberi.Core.Utilities.Interceptors;
using SeyahatRehberi.Core.Utilities.Security.JWT;
using SeyahatRehberi.DataAccess.Abstract;
using SeyahatRehberi.DataAccess.Concrete.EntityFramework;

namespace SeyahatRehberi.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<ArticleManager>().As<IArticleService>().SingleInstance();
            builder.RegisterType<EfArticleRepository>().As<IArticleRepository>().SingleInstance();

            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<EfCityRepository>().As<ICityRepository>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserRepository>().As<IUserRepository>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
