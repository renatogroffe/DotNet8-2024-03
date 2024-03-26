using System.ComponentModel.DataAnnotations;

namespace ConsoleAppAllowedValues.Models;

public class Estado
{
    [Required]
    [AllowedValues("CO", "N", "NE", "S", "SE", ErrorMessage = "Regiao invalida")]
    public string? CodRegiao { get; set; }
    
    [Required]
    public string? Nome { get; set; }
}