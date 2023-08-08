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
            //MVC yakla��m�n� kullanmak i�in ilgili service aktif ediyoruz.
            services.AddControllersWithViews().AddFluentValidation( x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
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
                //endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute("Custom", "{controller=Anasayfa}/{action=Anasayfa}/{a?}/{id?}");
            });
        }
    }
}
