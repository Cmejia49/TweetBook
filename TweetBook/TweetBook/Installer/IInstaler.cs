using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetBook.Installer
{
    public interface IInstaler
    {
        void InstallService(IServiceCollection services, IConfiguration configuration);
    }
}
