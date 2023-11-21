using AutoMapper;
using BlogFinalTask.Data;
using BlogFinalTask.Data.Models;
using BlogFinalTask.Data.Repository;
using BlogFinalTask.Services.AdministrationTools;
using BlogFinalTask.Web.Areas.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using NLog;
using NLog.Web;
using Radzen;
using System.Security.Claims;

namespace BlogFinalTask.Web
{
    public class Program
    {
        public static void Main(string[] args) {
            var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            logger.Debug("init main");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString), ServiceLifetime.Transient);
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddDefaultIdentity<CustomIdentity>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<CustomRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<CustomIdentity>>();
            builder.Services.AddTransient<IRepositoryCollection, RepositoryCollection>();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddAuthorization(options => {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole(ClaimTypes.Role, "Admin"));
                options.AddPolicy("RequireModeratorRole", policy => policy.RequireRole(ClaimTypes.Role, "Moderator"));
            });
            var mapperConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddScoped<AdministratorService>();

            builder.Logging.ClearProviders();
            builder.Host.UseNLog();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseMigrationsEndPoint();
            }
            else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseIPAddressMiddleware();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}