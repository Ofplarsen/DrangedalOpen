using Microsoft.IdentityModel.Protocols;

namespace WebAPI;

public static class ConfigConfiguration
{
    public static ConfigurationManager ConfigureConfig(this ConfigurationManager config)
    {
        
        config.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
        
        return config;
    }
    
}