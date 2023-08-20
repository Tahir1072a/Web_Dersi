using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Handlers;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //MVC yakla��m�n� kullanmak i�in ilgili service aktif ediyoruz.
            services.AddControllersWithViews().AddFluentValidation( x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
           // services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog())); //Default olarak singelton davran���n� kullan�r.
           ///* services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog(),ServiceLifetime.Transient));*/ //BU �ekilde de�i�tirilebilir. Ald���m�z hata aray�z yani interface uygulamas� gerekmektedir.

           // services.AddSingleton<ConsoleLog>(); //Bu �ekilde daha rahat container'a ekleyebiliriz.
           // /*services.AddSingleton<ConsoleLog>(p => new ConsoleLog(5));*/ //E�er ilgili s�n�f�n constructor� aparametre al�yorsu bu �ekilde ekelem yapmayl�y�z. Generic olarak ekleyemeyiz.

            services.AddScoped<ILog,ExampleIoC>();
            //services.AddScoped<ILog>(p => new TextLog());  //Asl�nda bu �ekilde ortak bir aray�zen hareket ediyoruz.
            //services.AddScoped<ILog, TextLog>(); // Constructer� bo� ise bu �ekilde bir i�lem yap�labilir.


            services.AddSingleton<IProductDal, EfDal>();
            
        }
        //Pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Gelen requestin rotas�, yani iste�in nereye hangi yap�ld��� burada belirlenir.
            app.UseStaticFiles();
            app.UseRouting();
            //�ste�in var�� noktas�d�r.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                     name: "MyArea1",
                     areaName: "y�netim_paneli",
                     pattern: "y�netim/{controller=Anasayfa}/{action=Index}"
                     );
                endpoints.MapAreaControllerRoute(
                    name: "MyArea2",
                    areaName: "fatura_y�netimi",
                    pattern: "fatura/{controller=Anasayfa}/{action=Index}"
                    );
                endpoints.Map("Example/{imageName}", new ExampleHandlers().Handler(env.WebRootPath));
                endpoints.MapControllerRoute("Custom", "{controller=Anasayfa}/{action=Anasayfa}/{a?}/{id?}");
                //endpoints.MapControllerRoute("Areas", "{area:exists}/{controller=Anasayfa}/{action=Index}/{id?}"); //exists constraint elimizdeki arealer ile e�le�tirme yap�lmas�n� sa�lar.

            });
        }
    }
}
