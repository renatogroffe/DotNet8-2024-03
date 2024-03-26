namespace FunctionAppContagem;

public class Contador
{
    public const int INCREMENTO = 1;
    private int _valorAtual = 0;

    public int ValorAtual { get => _valorAtual; }

    public void Incrementar()
    {
        _valorAtual += INCREMENTO;
    }        
}