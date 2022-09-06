using CarLocadora.Models.Models;
using CarLocadora.Negocio.Locacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoNegocio _locacaoNegocio;

        public LocacaoController(ILocacaoNegocio locacaoNegocio)
        {
            _locacaoNegocio = locacaoNegocio;
        }

        [HttpGet]
        public async Task<List<LocacaoModel>> Get()
        {
            return await _locacaoNegocio.ObterLista();
        }


        [HttpPost()]
        public async Task Post([FromBody] LocacaoModel locacao)
        {
            await _locacaoNegocio.Inserir(locacao);

        }
        [HttpPut()]
        public async Task Put([FromBody] LocacaoModel locacao)
        {
            await _locacaoNegocio.Alterar(locacao);

        }
        [HttpGet("ObterUmaLocacao")]
        public async Task<LocacaoModel> Get([FromQuery] int id)
        {
            return await _locacaoNegocio.ObterUmaLocacao(id);
        }
    }
}
