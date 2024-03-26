using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;

namespace FunctionAppContagem.Configurations;

public class OpenApiConfigurationOptions : DefaultOpenApiConfigurationOptions
{
    public override OpenApiInfo Info { get; set; } = new OpenApiInfo()
    {
        Version = "1.0.0",
        Title = $"Contagem de Acessos | Worker Runtime: {Environment.GetEnvironmentVariable("FUNCTIONS_WORKER_RUNTIME")}",
        Description = "API de contagem de acessos implementada com .NET 8 + Azure Functions",
        Contact = new OpenApiContact()
        {
            Name = "Renato Groffe",
            Url = new Uri("https://github.com/renatogroffe"),
        },
        License = new OpenApiLicense()
        {
            Name = "MIT",
            Url = new Uri("http://opensource.org/licenses/MIT"),
        }
    };

    public override OpenApiVersionType OpenApiVersion { get; set; } = OpenApiVersionType.V3;
}
