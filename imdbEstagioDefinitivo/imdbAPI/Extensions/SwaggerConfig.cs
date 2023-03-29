using IMDB.src.Api.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace imdbAPI.Extensions
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddCustomSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<BearerAuthenticationFilter>();

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer { token }\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
            });
            return services;
        }
    }
}