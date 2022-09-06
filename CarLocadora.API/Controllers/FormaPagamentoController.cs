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
        public async Task Post([FromBody] FormaPagamentoModel pagamento)
        {
            await _pagamento.Inserir(pagamento);

        }
        [HttpPut()]
        public async Task Put([FromBody] FormaPagamentoModel pagamento)
        {
            await _pagamento.Alterar(pagamento);

        }

        [HttpGet()]
        public async Task<List<FormaPagamentoModel>> Get()
        {
            return await _pagamento.ObterLista();
        }

        [HttpGet("ObterUmPagamento")]
        public async Task<FormaPagamentoModel> Get([FromQuery] int id)
        {
            return await _pagamento.ObterUmPagamento(id);
        }

    }
}
