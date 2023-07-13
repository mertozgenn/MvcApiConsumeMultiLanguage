using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Business.Utils.Localization;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HomeManager>().As<IHomeService>().SingleInstance();
            builder.RegisterType<Localization>().AutoActivate();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(GetProxyGenerationOptions())
                .SingleInstance();
        }

        private ProxyGenerationOptions GetProxyGenerationOptions()
        {
            return new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            };
        }
    }
}
