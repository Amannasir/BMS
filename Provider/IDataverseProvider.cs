namespace BMS.Providers
{
    using Microsoft.PowerPlatform.Dataverse.Client;

    public interface IDataverseProvider
    {
        ServiceClient GetServiceClient();
    }
}