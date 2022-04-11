using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBook.Data;
using TweetBook.Services;
using Microsoft.EntityFrameworkCore;
namespace TweetBook.Installer
{
    public class DbInstaller : IInstaler
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(optionsAction: options =>
            options.UseSqlServer(
                configuration.GetConnectionString(name: "DefualtConnection")));

            services.AddDefaultIdentity<IdentityUser>()
             .AddEntityFrameworkStores<DataContext>();

            services.AddSingleton<IPostService, CosmosPostService>();
        }
    }
}
