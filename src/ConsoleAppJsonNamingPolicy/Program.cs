using System.Runtime.InteropServices;
using System.Text.Json;
using ConsoleAppJsonNamingPolicy.Models;

Console.WriteLine("***** Testes com .NET 8 | Serializacao usando snake_case e kebab-case *****");
Console.WriteLine($"Versao do .NET em uso: {RuntimeInformation
    .FrameworkDescription} - Ambiente: {Environment.MachineName} - Kernel: {Environment
    .OSVersion.VersionString}");

var localidades = new Localidade[]
{
    new () { Id = 1, NomeCidade = "Sao Paulo", NomePais = "Brasil", NomeContinente = "America do Sul" },
    new () { Id = 2, NomeCidade = "Roma", NomePais = "Italia", NomeContinente = "Europa" }
};

Console.WriteLine();
Console.WriteLine("*** Resultados da serializacao ***");
foreach (var localidade in localidades)
{
    Console.WriteLine();
    Console.WriteLine($"Sem o uso de JsonNamingPolicy = {JsonSerializer.Serialize(localidade)}");
    PrintSerialization(localidade, JsonNamingPolicy.CamelCase);
    PrintSerialization(localidade, JsonNamingPolicy.SnakeCaseLower);
    PrintSerialization(localidade, JsonNamingPolicy.SnakeCaseUpper);
    PrintSerialization(localidade, JsonNamingPolicy.KebabCaseLower);
    PrintSerialization(localidade, JsonNamingPolicy.KebabCaseUpper);
}

static void PrintSerialization(Localidade localidade, JsonNamingPolicy policy) =>
    Console.WriteLine($"{policy.GetType().Name} = {JsonSerializer
        .Serialize(localidade, new JsonSerializerOptions { PropertyNamingPolicy = policy })}");