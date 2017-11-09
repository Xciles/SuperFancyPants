using System;
using System.Collections.Generic;
using System.Globalization;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperUserWeb.Business;
using SuperUserWeb.Business.Interfaces;
using SuperUserWeb.Data;
using SuperUserWeb.Domain;
using SuperUserWeb.Services;

namespace SuperUserWeb
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
            services.AddLocalization(o =>
            {
                // We will put our translations in a folder called Resources
                o.ResourcesPath = "Resources";
            });

            services.AddDbContext<FancyDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<UserAccount, IdentityRole>(x =>
                {
                    x.Password.RequireDigit = false;
                    x.Password.RequireNonAlphanumeric = false;
                    x.Password.RequireUppercase = false;
                    x.Password.RequireLowercase = false;
                })
                .AddEntityFrameworkStores<FancyDbContext>()
                .AddDefaultTokenProviders();

            // Setup options with DI
            services.AddOptions();

            // Configure MyOptions using code
            //services.Configure<NetOptions>(myOptions =>
            //{
            //    myOptions.NetStorage = Configuration.GetConnectionString("NetStorage");
            //});

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddTransient<IRoom, Business.Room>();

            services.AddMvc();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Domain.Room, Models.RoomViewModels.RoomViewModel>()
                    .ForMember(vm => vm.SizeAsInt, room => room.MapFrom(r => Convert.ToInt32(r.Size.ToString("D"))));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            IList<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("nl-NL"),
            };

            var options = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };
            app.UseRequestLocalization(options);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Initialize(serviceProvider);
            //Seeder.Initialize(serviceProvider);
        }
    }
}
