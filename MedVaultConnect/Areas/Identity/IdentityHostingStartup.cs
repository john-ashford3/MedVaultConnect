using System;
using MedVaultConnect.Areas.Identity.Data;
using MedVaultConnect.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(MedVaultConnect.Areas.Identity.IdentityHostingStartup))]
namespace MedVaultConnect.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MedVaultConnectContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MedVaultConnectContextConnection")));

                services.AddDefaultIdentity<MedVaultConnectUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MedVaultConnectContext>();
            });
        }
    }
}