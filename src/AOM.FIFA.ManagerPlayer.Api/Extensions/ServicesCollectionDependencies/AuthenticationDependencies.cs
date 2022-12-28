using Microsoft.Extensions.Configuration;
using AOM.FIFA.ManagerPlayer.Api.Constants;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies
{
    public static class AuthenticationDependencies
    {
        public static IServiceCollection AddingAuthenticationDependencies(this IServiceCollection services, IConfiguration configuration) 
        {          
            services.
                AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(options =>
                {                                        
                    options.Authority = configuration.GetValue<string>(ApiConstants.Domain);
                    options.Audience = configuration.GetValue<string>(ApiConstants.Audience);
                    options.RequireHttpsMetadata = false;
                }); 

            return services;
        }
    }
}
