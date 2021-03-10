using BookProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BookDbContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookConnection"]);

                //old sqlserver
                //options.UseSqlServer(Configuration["ConnectionStrings:BookConnection"]);
            });

            //each session is going to get it's own scoped version of the database 
            services.AddScoped<IBookRepository, EFBookRepository>();

            //adding Razor Pages.. also added endpoint below
            services.AddRazorPages();

            //gets the information "to stick"
            services.AddDistributedMemoryCache();

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //allows the user to get stuff and add it to a cart, then it will sit there while they navigate around the site
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();


            //When searching for endpoints, if it hits one, it will go with that one. It will not continue searching for routes
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("catpage",
                    "{category}/{pageNum:int}",
                    new { Controller = "Home", action = "Index" }
                    );

                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", pageNum = 1 }
                    );

                endpoints.MapControllerRoute("pagination",
                    "P/{pageNum}",
                    new { Controller = "Home", action = "Index" });


                //Default endpoint if there are no parameters
                endpoints.MapDefaultControllerRoute();

                //Razor Pages -- also added services above
                endpoints.MapRazorPages();
            });

            SeedData.EnsurePopulated(app);



        }
    }
}
