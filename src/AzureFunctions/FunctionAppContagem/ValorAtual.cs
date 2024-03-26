using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using FunctionAppContagem.Models;

namespace FunctionAppContagem;

public class ValorAtual
{
    private readonly ILogger _logger;
    private readonly Contador _contador;

    public ValorAtual(ILoggerFactory loggerFactory,
        Contador contador)
    {
        _logger = loggerFactory.CreateLogger<ValorAtual>();
        _contador = contador;
    }

    [Function(nameof(ValorAtual))]
    [OpenApiOperation(operationId: nameof(ValorAtual), tags: new[] { "ValorAtual" })]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ResultadoContador), Description = "Resultado da contagem de acessos")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
    {
        int valorAtualContador;
        lock (_contador)
        {
            _contador.Incrementar();
            valorAtualContador = _contador.ValorAtual;
        }

        if (Convert.ToBoolean(Environment.GetEnvironmentVariable("SimularFalha")) &&
            valorAtualContador % 4 == 0)
        {
            _logger.LogError("Simulando falha...");
            throw new Exception("Simulação de falha!");
        }

        _logger.LogInformation($"Contador - Valor atual: {valorAtualContador}");

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.WriteAsJsonAsync(new ResultadoContador(valorAtualContador));
        return response;
    }
}
