using CarLocadora.Models.Models;
using CarLocadora.Negocio.FormaPagamento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FormaPagamentoController : ControllerBase
    {
        private readonly IFormaPagamentoNegocio _pagamento;
        public FormaPagamentoController(IFormaPagamentoNegocio pagamento)
        {
            _pagamento = pagamento;
        }

        [HttpPost()]
        public void Post([FromBody] FormaPagamentoModel pagamento)
        {
            _pagamento.Inserir(pagamento);

        }
        [HttpPut()]
        public void Put([FromBody] FormaPagamentoModel pagamento)
        {
            _pagamento.Alterar(pagamento);

        }

        [HttpGet()]
        public List<FormaPagamentoModel> Get()
        {
            return _pagamento.ObterLista();
        }

        [HttpGet("ObterUmPagamento")]
        public FormaPagamentoModel Get([FromQuery] int id)
        {
            return _pagamento.ObterUmPagamento(id);
        }

    }
}
