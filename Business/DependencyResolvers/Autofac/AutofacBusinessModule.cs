using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<DpCityDal>().As<ICityDal>().SingleInstance();

            builder.RegisterType<PhotoManager>().As<IPhotoService>().SingleInstance();
            builder.RegisterType<DpPhotoDal>().As<IPhotoDal>().SingleInstance();

            builder.RegisterType<PersonManager>().As<IPersonService>().SingleInstance();
            builder.RegisterType<DpPersonDal>().As<IPersonDal>().SingleInstance();

            //var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            //builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            //    .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            //    {
            //        Selector = new AspectInterceptorSelector()
            //    }).SingleInstance();
        }
    }
}
