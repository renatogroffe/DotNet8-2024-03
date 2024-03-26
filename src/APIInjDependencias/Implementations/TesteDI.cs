using APIInjDependencias.Interfaces;

namespace APIInjDependencias.Implementations;

public class TesteDI : ITesteDI
{
    public Guid IdReferencia { get; }

    public TesteDI()
    {
        this.IdReferencia = Guid.NewGuid();
    }
}
