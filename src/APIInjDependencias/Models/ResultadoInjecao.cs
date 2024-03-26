namespace APIInjDependencias.Models;

public class ResultadoInjecao
{
    public string Horario => $"{DateTime.Now:HH:mm:ss}";
    public ValoresInjecaoUsandoKey? ValoresA { get; set; }
    public ValoresInjecaoUsandoKey? ValoresB { get; set; }
}

public class ValoresInjecaoUsandoKey
{
    public string? Key { get; set; }
    public Guid Construtor { get; set; }
    public Guid Action { get; set; }

    public override string ToString() =>
        $"Key = {Key} - Construtor: {Construtor.ToString()} - Action: {Action.ToString()}";
}
