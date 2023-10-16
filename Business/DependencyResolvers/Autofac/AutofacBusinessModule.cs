using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Utilities.Interceptors.AspectInterceptorSelectors;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)    //override dediğimizde methodlara erişebiliyoruz. Load yükleme yapar uygulama çalıştığı an load da çalışıcak.
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();  //Birisi senden IProductService isterse ona ProductManager ver.   
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

           
            
              //AOP; Aşağıda ki kodlar yukarıda ki sınıfların aspecti var mı diye kontrol eder ve var ise attribute çalıştırır.
            
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
