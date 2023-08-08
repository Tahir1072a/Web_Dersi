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

namespace WebApplication1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //MVC yaklaþýmýný kullanmak için ilgili service aktif ediyoruz.
            services.AddControllersWithViews().AddFluentValidation( x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
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
                //endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute("Custom", "{controller=Anasayfa}/{action=Anasayfa}/{a?}/{id?}");
            });
        }
    }
}
