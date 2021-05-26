using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using BAE_Brasil.DataSource;
using BAE_Brasil.DataSource.SeedData;
using BAE_Brasil.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BAE_Brasil
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
            services.AddMvc();
            services.AddControllersWithViews();

            services.AddAutoMapper(typeof(Startup));
            
            services.AddDistributedMemoryCache();
            
            var currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var dbPath = Path.Combine(currentPath ?? ".", Configuration.GetConnectionString("IdentityDb"));
            
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite($"Filename={dbPath}");
            });
            
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(120);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IResumeService, ResumeService>();
            services.AddScoped<ICandidateFilterService, CandidateFilterService>();
            services.AddScoped<IAuthorizationPolicyEnforcementService, AuthorizationPolicyEnforcementService>();

            var context = GetDbContext(services);
            MigrateIfAny(context);
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
            }
            
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseHsts();
            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void MigrateIfAny(AppDbContext context)
        {
            if (context.Database.GetMigrations().Any())
            {
                context.Database.Migrate();
            }

        }

        private AppDbContext GetDbContext(IServiceCollection services)
        {
            var sp = services.BuildServiceProvider().CreateScope();
            var context = sp.ServiceProvider.GetRequiredService<AppDbContext>();
            return context;
        }
        
    }
}