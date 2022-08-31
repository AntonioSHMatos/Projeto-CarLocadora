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
        public List<LocacaoModel> Get()
        {
            return _locacaoNegocio.ObterLista();
        }


        [HttpPost()]
        public void Post([FromBody] LocacaoModel locacao)
        {
            _locacaoNegocio.Inserir(locacao);

        }
        [HttpPut()]
        public void Put([FromBody] LocacaoModel locacao)
        {
            _locacaoNegocio.Alterar(locacao);

        }
        [HttpGet("ObterUmaLocacao")]
        public LocacaoModel Get([FromQuery] int id)
        {
            return _locacaoNegocio.ObterUmaLocacao(id);
        }
    }
}
