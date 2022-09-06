using CarLocadora.Models.Models;
using CarLocadora.Negocio.Vistoria;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VistoriaController : ControllerBase
    {
        private readonly IVistoriaNegocio _vistoriaNegocio;

        public VistoriaController(IVistoriaNegocio vistoriaNegocio)
        {
            _vistoriaNegocio = vistoriaNegocio;
        }

        [HttpGet]
        public async Task <List<VistoriaModel>> Get()
        {
            return await _vistoriaNegocio.ObterLista();
        }


        [HttpPost()]
        public async Task Post([FromBody] VistoriaModel vistoria)
        {
            await _vistoriaNegocio.Inserir(vistoria);

        }
        [HttpPut()]
        public async Task Put([FromBody] VistoriaModel vistoria)
        {
            await _vistoriaNegocio.Alterar(vistoria);

        }
        [HttpGet("ObterUmaVistoria")]
        public async Task<VistoriaModel> Get([FromQuery] int id)
        {
            return await _vistoriaNegocio.ObterUmaVistoria(id);
        }
    }
}
