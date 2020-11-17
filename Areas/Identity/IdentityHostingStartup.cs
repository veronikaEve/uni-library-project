using System;
using CO550LIbrary.Areas.Identity.Data;
using CO550LIbrary.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CO550LIbrary.Areas.Identity.IdentityHostingStartup))]
namespace CO550LIbrary.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CO550LIbraryDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CO550LIbraryDBContextConnection")));

                services.AddDefaultIdentity<Appuser>(options => options.SignIn.RequireConfirmedAccount = false)

                    .AddEntityFrameworkStores<CO550LIbraryDBContext>();
            });
        }
    }
}