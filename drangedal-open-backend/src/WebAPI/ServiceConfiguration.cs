using System.Text;
using Common.Database;
using Common.Models;
using Common.Options;
using InternalServices.DataAccess;
using InternalServices.DataAccess.Interfaces;
using InternalServices.Repository;
using InternalServices.Repository.Interfaces;
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
        service.AddSingleton(new DatabaseOption()
        {
            Db = config.GetValue<string>("Database:Db"),
            Host = config.GetValue<string>("Database:Host"), Password = config.GetValue<string>("Database:Password"),
            Username = config.GetValue<string>("Database:Username")
        });
        service.AddScoped<IDbConnection, DbConnection>();
        
        
        //Services
        service.AddScoped<ITournamentService, TournamentService>();
        service.AddScoped<ITournamentRepository, TournamentRepository>();
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IUserRepository, UserRepository>();
        service.AddScoped<IUserDA, UserDA>();
        service.AddScoped<IRatingService, RatingService>();
        service.AddScoped<IRankingRepository, RankingRepository>();
        service.AddScoped<IRankingDA, RankingDA>();
        service.AddScoped<IMatchService, MatchService>();
        service.AddScoped<IMatchDA, MatchDA>();
        service.AddScoped<IMatchRepository, MatchRepository>();
        service.AddScoped<IPlayerService, PlayerService>();
        service.AddScoped<IPlayerDA, PlayerDA>();
        service.AddScoped<IPlayerRepository, PlayerRepository>();
        return service;
    }
}