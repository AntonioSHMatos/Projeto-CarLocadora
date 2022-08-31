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
        public List<VistoriaModel> Get()
        {
            return _vistoriaNegocio.ObterLista();
        }


        [HttpPost()]
        public void Post([FromBody] VistoriaModel vistoria)
        {
            _vistoriaNegocio.Inserir(vistoria);

        }
        [HttpPut()]
        public void Put([FromBody] VistoriaModel vistoria)
        {
            _vistoriaNegocio.Alterar(vistoria);

        }
        [HttpGet("ObterUmaVistoria")]
        public VistoriaModel Get([FromQuery] int id)
        {
            return _vistoriaNegocio.ObterUmaVistoria(id);
        }
    }
}
