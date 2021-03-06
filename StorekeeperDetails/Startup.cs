using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StorekeeperDetails.EfStuff;
using StorekeeperDetails.EfStuff.DbModel;
using StorekeeperDetails.EfStuff.Repositories;
using StorekeeperDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorekeeperDetails
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StoreKD;Integrated Security=True;";
            services.AddDbContext<WebContext>(x => x.UseSqlServer(connectString));

            services.AddScoped<DetailRepository>();
            services.AddScoped<StoreKeeperRepository>();

            var provider = new MapperConfigurationExpression();
            provider.CreateMap<Detail, DetailViewModel>()
                .ForMember(dview => dview.KeeperId, db => db.MapFrom(detail => detail.Keeper.Id))
                .ForMember(dview => dview.KeeperName, db => db.MapFrom(detail => detail.Keeper.Name));

            provider.CreateMap<DetailViewModel, Detail>();

            provider.CreateMap<StoreKeeper, StoreKeeperViewModel>();
            provider.CreateMap<StoreKeeperViewModel, StoreKeeper>();

            var mapperConfiguration = new MapperConfiguration(provider);
            var mapper = new Mapper(mapperConfiguration);
            services.AddScoped<IMapper>(x => mapper);


            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            services.AddSignalR();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
