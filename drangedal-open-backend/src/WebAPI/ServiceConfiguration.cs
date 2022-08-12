using System.Text;
using Common.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using InternalServices.Service.Interfaces;
using InternalServices.Service;
namespace WebAPI;

public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureService(this IServiceCollection service, ConfigurationManager config)
    {
              
        service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)    
            .AddJwtBearer(options =>    
            {    
                options.TokenValidationParameters = new TokenValidationParameters    
                {    
                    ValidateIssuer = true,    
                    ValidateAudience = true,    
                    ValidateLifetime = true,    
                    ValidateIssuerSigningKey = true,    
                    ValidIssuer = config.GetValue<string>("Jwt:Issuer"),    
                    ValidAudience = config.GetValue<string>("Jwt:Issuer"),    
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetValue<string>("Jwt:Key")))    
                };    
            }); 
        
        service.AddScoped<IAuthenticationService, AuthenticationService>();
        service.AddScoped<IUserService, UserService>();
        return service;
    }
}