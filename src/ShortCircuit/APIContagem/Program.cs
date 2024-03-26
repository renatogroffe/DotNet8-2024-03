using APIContagem;
using APIContagem.Middlewares;
using APIContagem.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Contador>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseMiddlewareExecutionNotificator();

app.MapGet("/status", () =>
{
    app.Logger.LogInformation("Acionado endpoint de Health Check");
    return "API Contagem - OK";
}).ShortCircuit();

app.MapGet("/contador", (Contador contador) =>
{
    int valorAtualContador;
    lock (contador)
    {
        contador.Incrementar();
        valorAtualContador = contador.ValorAtual;
    }
    app.Logger.LogInformation($"Contador - Valor atual: {valorAtualContador}");

    return TypedResults.Ok(new ResultadoContador()
    {
        ValorAtual = contador.ValorAtual,
        Local = contador.Local,
        Kernel = contador.Kernel,
        Framework = contador.Framework,
        Mensagem = app.Configuration["Saudacao"]
    });
}).Produces<ResultadoContador>().WithOpenApi();

app.MapShortCircuit(404, "robots.txt", "favicon.ico");

app.Run();