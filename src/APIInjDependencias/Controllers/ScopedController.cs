using APIInjDependencias.Interfaces;
using APIInjDependencias.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIInjDependencias.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScopedController : ControllerBase
    {
        private readonly ILogger<ScopedController> _logger;
        private readonly ITesteDI _scopedA;
        private readonly ITesteDI _scopedB;

        public ScopedController(ILogger<ScopedController> logger,
            [FromKeyedServices("ScopedA")] ITesteDI scopedA,
            [FromKeyedServices("ScopedB")] ITesteDI scopedB)
        {
            _logger = logger;
            _scopedA = scopedA;
            _scopedB = scopedB;
        }

        [HttpGet]
        public ResultadoInjecao Get(IServiceProvider serviceProvider)
        {
            var scopedA_Action = serviceProvider.GetRequiredKeyedService<ITesteDI>("ScopedA");
            var scopedB_Action = serviceProvider.GetRequiredKeyedService<ITesteDI>("ScopedB");
            var resultado = new ResultadoInjecao();
            resultado.ValoresA = new ValoresInjecaoUsandoKey
            {
                Key = "ScopedA",
                Construtor = _scopedA.IdReferencia,
                Action = scopedA_Action.IdReferencia
            };
            resultado.ValoresB = new ValoresInjecaoUsandoKey
            {
                Key = "ScopedB",
                Construtor = _scopedB.IdReferencia,
                Action = scopedB_Action.IdReferencia
            };
            _logger.LogInformation(resultado.ValoresA.ToString());
            _logger.LogInformation(resultado.ValoresB.ToString());
            return resultado;
        }
    }
}
