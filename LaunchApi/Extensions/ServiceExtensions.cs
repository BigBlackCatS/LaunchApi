using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace LaunchApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "Launch Api" });
                c.SwaggerDoc("v2", new OpenApiInfo { Version = "v2", Title = "Launch Api" });

                //To avoid exception about the same name for different schemas in portals
                c.CustomSchemaIds(type => type.ToString());

                c.DocInclusionPredicate((version, desc) =>
                {
                    if (!desc.TryGetMethodInfo(out var methodInfo))
                    {
                        return false;
                    }

                    if (methodInfo.DeclaringType == null)
                    {
                        return false;
                    }

                    var versions = methodInfo.DeclaringType
                        .GetCustomAttributes(true)
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions);

                    return versions.Any(v => version.Contains($"v{v}"));
                });
            });
        }

        public static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                var defaultVersion = new ApiVersion(1, 0);
                config.DefaultApiVersion = defaultVersion;
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            // group API's of the same version
            object value = services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = $"'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            // this is required to search for versions
            services.AddEndpointsApiExplorer();
        }
    }
}
