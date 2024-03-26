using APIInjDependencias.Interfaces;
using APIInjDependencias.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIInjDependencias.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SingletonController : ControllerBase
    {
        private readonly ILogger<SingletonController> _logger;
        private readonly ITesteDI _singletonA;
        private readonly ITesteDI _singletonB;

        public SingletonController(ILogger<SingletonController> logger,
            [FromKeyedServices("SingletonA")] ITesteDI singletonA,
            [FromKeyedServices("SingletonB")] ITesteDI singletonB)
        {
            _logger = logger;
            _singletonA = singletonA;
            _singletonB = singletonB;
        }

        [HttpGet]
        public ResultadoInjecao Get(
            [FromKeyedServices("SingletonA")] ITesteDI singletonA_Action,
            [FromKeyedServices("SingletonB")] ITesteDI singletonB_Action)
        {
            var resultado = new ResultadoInjecao();
            resultado.ValoresA = new ValoresInjecaoUsandoKey
            {
                Key = "SingletonA",
                Construtor = _singletonA.IdReferencia,
                Action = singletonA_Action.IdReferencia
            };
            resultado.ValoresB = new ValoresInjecaoUsandoKey
            {
                Key = "SingletonB",
                Construtor = _singletonB.IdReferencia,
                Action = singletonB_Action.IdReferencia
            };
            _logger.LogInformation(resultado.ValoresA.ToString());
            _logger.LogInformation(resultado.ValoresB.ToString());
            return resultado;
        }
    }
}
