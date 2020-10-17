using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GaripSozluk.Business.Interfaces;
using GaripSozluk.Business.Services;
using GaripSozluk.Data;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using GaripSozluk.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieStore.WebApp.Extensions;

namespace GaripSozluk.WebApp
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

            var connectionString = Configuration.GetConnectionString("AppDatabase");
            var connectionStringPostgre = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<GaripSozlukDbContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<LogDbContext>(options => options.UseNpgsql(connectionStringPostgre));

            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IRestSharpService, RestSharpService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IBlockedUserService, BlockedUserService>();
            services.AddScoped<IPostCategoryService, PostCategoryService>();
            services.AddScoped<IEntryService, EntryService>();
            services.AddScoped<IEntryRatingService, EntryRatingService>();

            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostCategoryRepository, PostCategoryRepository>();
            services.AddScoped<IEntryRepository, EntryRepository>();
            services.AddScoped<IEntryRatingRepository, EntryRatingRepository>();
            services.AddScoped<IBlockedUserRepository, BlockedUserRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
                
            services.AddHttpContextAccessor();

            //services.AddTransient<ClaimsPrincipal>(s => s.GetService<IHttpContextAccessor>().HttpContext.User);

            services.AddIdentity<User, Role>()
              .AddRoles<Role>()
              .AddRoleManager<RoleManager<Role>>()
              .AddEntityFrameworkStores<GaripSozlukDbContext>()
              .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.Configure<IdentityOptions>(options =>
            {

                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 4;

                // User settings
                options.User.RequireUniqueEmail = true;
            });


            services.AddControllersWithViews().AddRazorRuntimeCompilation(); 
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

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<ExecutionTimeMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
