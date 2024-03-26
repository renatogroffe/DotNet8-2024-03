using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.Json;
using ConsoleAppDeniedValues.Models;

Console.WriteLine("***** Testes com .NET 8 | DeniedValuesAttribute *****");
Console.WriteLine($"Versao do .NET em uso: {RuntimeInformation
    .FrameworkDescription} - Ambiente: {Environment.MachineName} - Kernel: {Environment
    .OSVersion.VersionString}");

var projetos = new Projeto[]
{
    new() { TargetFramework = "net7.0", Descricao = "Worker Consolidacao Bancaria" },
    new() { TargetFramework = "net5.0", Descricao = "Extensao para Dapper" },
    new() { TargetFramework = "net6.0", Descricao = "API Meio Pagamento" },
    new() { TargetFramework = "netcoreapp3.1", Descricao = "API Consolidacao Bancaria" },
    new() { TargetFramework = "net8.0", Descricao = "Worker Pagamentos" }
};

foreach (var estado in projetos)
{
    Console.WriteLine();
    Console.WriteLine(JsonSerializer.Serialize(estado));
    var validationResults = new List<ValidationResult>();
    if (!Validator.TryValidateObject(estado, new ValidationContext(estado),
        validationResults, validateAllProperties: true))
    {
        Console.WriteLine("Dados invalidos para essa instancia...");
        foreach (var validationResult in validationResults)
            Console.WriteLine($"ErrorMessage = {validationResult.ErrorMessage}");
    }
}