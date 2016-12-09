using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CqrsModels = PinoyCode.Cqrs.Models;
using PinoyCode.Data;
using PinoyCode.Domain.Identity;
using PinoyCode.Domain.Identity.Models;
using PinoyCode.Web.Services;
using System;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PinoyCode.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddEntityFrameworkSqlServer()
                  .AddDbContext<ApplicationIdentityDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                     c => c.MigrationsAssembly("PinoyCode.Web")))
                   .AddDbContext<DbContextBase>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), 
                     c => c.MigrationsAssembly("PinoyCode.Web")));

            services.AddIdentity<User, Role>(options => {
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 5;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                })
                .AddEntityFrameworkStores<ApplicationIdentityDbContext, Guid>()
                .AddDefaultTokenProviders();

            services.AddMvc();

           
            // Add application services.
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<ISignInManager, SignInManager>();

            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


            using (var db = app.ApplicationServices.GetService<DbContextBase>())
            {
                db.OnModelCreated += (ModelBuilder b) =>
                {
                    // Add mapping tables
                    b.Entity<CqrsModels.Aggregate>(t =>
                    {
                        t.Property(p => p.Id)
                           .IsRequired();
                        t.Property(p => p.AggregateType);
                        t.Property(p => p.CommitDateTime);
                        t.HasKey(p => p.Id);
                        t.HasMany(p => p.Events)
                          .WithOne()
                          .HasForeignKey(p => p.AggregateId)
                          .OnDelete(DeleteBehavior.Cascade);
                        t.ToTable("Aggregates");
                    });

                    b.Entity<CqrsModels.Event>(t =>
                    {
                        t.Property(p => p.Id)
                           .IsRequired();
                        t.Property(p => p.AggregateId);
                        t.Property(p => p.CommitDateTime);
                        t.Property(p => p.SequenceNumber);
                        t.Property(p => p.Type);
                        t.Property(p => p.Body);
                        t.HasKey(p => p.Id);
                        t.HasIndex(p => p.AggregateId);
                        t.HasOne(p => p.Aggregate)
                          .WithMany()
                          .HasForeignKey(p => p.AggregateId)
                          .OnDelete(DeleteBehavior.Cascade);
                       
                        t.ToTable("Events");
                    });
                };
            }

                app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
