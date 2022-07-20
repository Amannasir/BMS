namespace BMS.Providers
{
    using BMS.Data.Model;
    using Microsoft.Extensions.Options;
    using Microsoft.PowerPlatform.Dataverse.Client;

    public class DataverseProvider : IDataverseProvider
    {
        readonly DataverseConfig config;
        public DataverseProvider(IOptions<DataverseConfig> options)
        {
            this.config = options.Value;
        }

        public ServiceClient GetServiceClient()
        {
            var connectionString = @$"SkipDiscovery=true;url={config.BaseUrl};ClientId={config.ClientId};AuthType=ClientSecret;ClientSecret={config.ClientSecret}";
            var client = new ServiceClient(connectionString);
            return client;
        }
    }
}
