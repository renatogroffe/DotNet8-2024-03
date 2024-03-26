using System.ComponentModel.DataAnnotations;

namespace ConsoleAppDeniedValues.Models;

public class Projeto
{
    [Required]
    [DeniedValues("netcoreapp3.1", "net5.0", ErrorMessage = "SDK invalido")]
    public string? TargetFramework { get; set; }

    [Required]
    public string? Descricao { get; set; }
}