using System;
using DibawinWebsite.Areas.Identity.Data;
using DibawinWebsite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(DibawinWebsite.Areas.Identity.IdentityHostingStartup))]
namespace DibawinWebsite.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DibawinWebsiteContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DibawinWebsiteContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>()
                    .AddEntityFrameworkStores<DibawinWebsiteContext>();
            });
        }
    }
}