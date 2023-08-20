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
            //MVC yaklaþýmýný kullanmak için ilgili service aktif ediyoruz.
            services.AddControllersWithViews().AddFluentValidation( x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
           // services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog())); //Default olarak singelton davranýþýný kullanýr.
           ///* services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog(),ServiceLifetime.Transient));*/ //BU þekilde deðiþtirilebilir. Aldýðýmýz hata arayüz yani interface uygulamasý gerekmektedir.

           // services.AddSingleton<ConsoleLog>(); //Bu þekilde daha rahat container'a ekleyebiliriz.
           // /*services.AddSingleton<ConsoleLog>(p => new ConsoleLog(5));*/ //Eðer ilgili sýnýfýn constructorý aparametre alýyorsu bu þekilde ekelem yapmaylýyýz. Generic olarak ekleyemeyiz.

            services.AddScoped<ILog,ExampleIoC>();
            //services.AddScoped<ILog>(p => new TextLog());  //Aslýnda bu þekilde ortak bir arayüzen hareket ediyoruz.
            //services.AddScoped<ILog, TextLog>(); // Constructerý boþ ise bu þekilde bir iþlem yapýlabilir.


            services.AddSingleton<IProductDal, EfDal>();
            
        }
        //Pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Gelen requestin rotasý, yani isteðin nereye hangi yapýldýðý burada belirlenir.
            app.UseStaticFiles();
            app.UseRouting();
            //Ýsteðin varýþ noktasýdýr.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                     name: "MyArea1",
                     areaName: "yönetim_paneli",
                     pattern: "yönetim/{controller=Anasayfa}/{action=Index}"
                     );
                endpoints.MapAreaControllerRoute(
                    name: "MyArea2",
                    areaName: "fatura_yönetimi",
                    pattern: "fatura/{controller=Anasayfa}/{action=Index}"
                    );
                endpoints.Map("Example/{imageName}", new ExampleHandlers().Handler(env.WebRootPath));
                endpoints.MapControllerRoute("Custom", "{controller=Anasayfa}/{action=Anasayfa}/{a?}/{id?}");
                //endpoints.MapControllerRoute("Areas", "{area:exists}/{controller=Anasayfa}/{action=Index}/{id?}"); //exists constraint elimizdeki arealer ile eþleþtirme yapýlmasýný saðlar.

            });
        }
    }
}
