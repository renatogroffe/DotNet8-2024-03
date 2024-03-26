using APIInjDependencias.Interfaces;
using APIInjDependencias.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIInjDependencias.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransientController : ControllerBase
    {
        private readonly ILogger<TransientController> _logger;
        private readonly ITesteDI _transientA;
        private readonly ITesteDI _transientB;

        public TransientController(ILogger<TransientController> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _transientA = serviceProvider.GetRequiredKeyedService<ITesteDI>("TransientA");
            _transientB = serviceProvider.GetRequiredKeyedService<ITesteDI>("TransientB");
        }

        [HttpGet]
        public ResultadoInjecao Get(
            [FromKeyedServices("TransientA")] ITesteDI transientA_Action,
            [FromKeyedServices("TransientB")] ITesteDI transientB_Action)
        {
            var resultado = new ResultadoInjecao();
            resultado.ValoresA = new ValoresInjecaoUsandoKey
            {
                Key = "TransientA",
                Construtor = _transientA.IdReferencia,
                Action = transientA_Action.IdReferencia
            };
            resultado.ValoresB = new ValoresInjecaoUsandoKey
            {
                Key = "TransientB",
                Construtor = _transientB.IdReferencia,
                Action = transientB_Action.IdReferencia
            };
            _logger.LogInformation(resultado.ValoresA.ToString());
            _logger.LogInformation(resultado.ValoresB.ToString());
            return resultado;
        }
    }
}
