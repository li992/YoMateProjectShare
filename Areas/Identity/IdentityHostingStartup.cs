using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YoMateProjectShare.Data;
using YoMateProjectShare.Areas.Identity.Data;

[assembly: HostingStartup(typeof(YoMateProjectShare.Areas.Identity.IdentityHostingStartup))]
namespace YoMateProjectShare.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<YoMateProjectShareDBContext>(options =>
                    options.UseSqlServer(
#if (DEBUG == false)
                        context.Configuration.GetConnectionString("YoMateProDB")));
#else
                        context.Configuration.GetConnectionString("YoMateProjectShareDev")));
#endif

                services.AddDefaultIdentity<UserInfo>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<YoMateProjectShareDBContext>();
            });
        }
    }
}