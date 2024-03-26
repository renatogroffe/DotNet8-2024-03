using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.Json;
using ConsoleAppAllowedValues.Models;

Console.WriteLine("***** Testes com .NET 8 | AllowedValuesAttribute *****");
Console.WriteLine($"Versao do .NET em uso: {RuntimeInformation
    .FrameworkDescription} - Ambiente: {Environment.MachineName} - Kernel: {Environment
    .OSVersion.VersionString}");

var estados = new Estado[]
{
    new() {CodRegiao = "SE", Nome = "Sao Paulo"},
    new() {CodRegiao = "NE", Nome = "Bahia"},
    new() {CodRegiao = "CO", Nome = "Mato Grosso"},
    new() {CodRegiao = "L", Nome = "Teste com Regiao invalida"},
    new() {CodRegiao = "S", Nome = "Rio Grande do Sul"},
    new() {CodRegiao = "N", Nome = "Para"}
};

foreach (var estado in estados)
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