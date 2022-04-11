using Cosmonaut;
using Cosmonaut.Extensions.Microsoft.DependencyInjection;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBook.Domain;

namespace TweetBook.Installer
{
    public class CosmosInstaller : IInstaler
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            var cosmosStoreSettings = new CosmosStoreSettings(
                    databaseName: configuration["CosmosSettings:DatabaseName"],
                    endpointUrl: configuration["CosmosSettings:AccountUri"],
                    authKey: configuration["CosmosSettings:AccountKey"],
                    new ConnectionPolicy { ConnectionMode = ConnectionMode.Direct, ConnectionProtocol = Protocol.Tcp });

            services.AddCosmosStore<CosmosPostDto>(cosmosStoreSettings);
        }
    }
}
