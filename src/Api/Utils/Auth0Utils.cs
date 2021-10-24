using System.IO;
using System.Security.Cryptography;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CzyDobrze.Api.Utils
{
    public static class Auth0Utils
    {
        public static IServiceCollection AddAuth0(this IServiceCollection services)
        {
            var rsa = RSA.Create();
            rsa.FromXmlString(File.ReadAllText("rsa.xml"));
            var securityKey = new RsaSecurityKey(rsa);

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://dev-wop8zm8z.eu.auth0.com/";
                    options.Audience = "https://czydobrze.bazik.xyz";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = "azp",
                        RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                        IssuerSigningKey = securityKey
                    };
                });

            services.AddHttpContextAccessor();
            services.AddTransient<ICurrentUserService, CurrentUserService>();

            return services;
        }

        public static IApplicationBuilder UseAuth0(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}