using CarLocadora.Negocio.FormaPagamento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaPagamentoController : ControllerBase
    {
        private readonly IFormaPagamentoNegocio _pagamento;
        public FormaPagamentoController(IFormaPagamentoNegocio pagamento)
        {
            _pagamento = pagamento;
        }

        [HttpPost()]
        public void Post([FromBody] FormaPagamentoNegocio pagamento)
        {
            _pagamento.Inserir(pagamento);

        }
        [HttpPut()]
        public void Put([FromBody] FormaPagamentoNegocio pagamento)
        {
            _pagamento.Alterar(pagamento);

        }




    }
}
