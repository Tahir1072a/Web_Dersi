using Microsoft.Extensions.DependencyInjection;
using System;
using WebApplication1.Services;

namespace WebApplication1
{
    public class ExampleIoC : ILog
    {
        IProductDal dal;
        public ExampleIoC(IProductDal productDal)
        {
            dal = productDal;
            //IServiceCollection services = new ServiceCollection(); //built - in IoC Konteyner.
            //services.Add(new ServiceDescriptor(typeof(ConsoleLog),new ConsoleLog()); //Bu konteynırımıza ekleme yapmak istediğimiz sınıfı ekler.
            ////ServiceDescriptor => Servis tanımlayıcı alır parametre olarak. 

            ////Somut/container
            //ServiceProvider provider = services.BuildServiceProvider(); //ServicesProvider => servis sağlayıcı olarak return eder. 
            //provider.GetService<ConsoleLog>(); // İlgili sınıfı return eder.
        }

        public void Log()
        {
            Console.WriteLine("Example");
        }
    }
}
