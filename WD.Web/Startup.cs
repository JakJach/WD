using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;
using WD.Data.Models;
using WD.Data.Services;
using WD.Web.Models;

namespace WD.Web
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
            services.AddControllersWithViews();

            services.AddScoped<IWDRepository, WDRepository>();
            services.AddScoped<IUser, User>();

            //downloading files
            services.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            //Classes context
            services.AddEntityFrameworkNpgsql().AddDbContextPool<ClassesContext>(opt =>
               opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("WD.Web")));

            //Project context
            services.AddEntityFrameworkNpgsql().AddDbContextPool<ProjectContext>(opt =>
               opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("WD.Web")));

            //Student context
            services.AddEntityFrameworkNpgsql().AddDbContextPool<StudentContext>(opt =>
               opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("WD.Web")));

            //Teacher context
            services.AddEntityFrameworkNpgsql().AddDbContextPool<TeacherContext>(opt =>
               opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("WD.Web")));

            //Thesis context
            services.AddEntityFrameworkNpgsql().AddDbContextPool<ThesisContext>(opt =>
               opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("WD.Web")));

            //User context
            services.AddEntityFrameworkNpgsql().AddDbContextPool<UserContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("WD.Web")));

            //Login services
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 0;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<UserContext>();
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
