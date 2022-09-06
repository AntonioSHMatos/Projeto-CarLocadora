using CarLocadora.Models.Models;
using CarLocadora.Negocio.Categoria;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaNegocio _categoriaNegocio;

        public CategoriaController(ICategoriaNegocio categoriaNegocio)
        {
            _categoriaNegocio = categoriaNegocio;
        }
        
        [HttpDelete()]
        public async Task Deletar([FromQuery]int Id)
        {
           await  _categoriaNegocio.Excluir(Id);
        }

        [HttpGet]
        public async Task<List<CategoriaModel>> Get()
        {
            return await _categoriaNegocio.ObterLista();
        }


        [HttpPost()]
        public async Task Post([FromBody] CategoriaModel categoriaNegocio)
        {
            await _categoriaNegocio.Inserir(categoriaNegocio);

        }
        [HttpPut()]
        public async Task Put([FromBody] CategoriaModel categoriaNegocio)
        {
            _categoriaNegocio.Alterar(categoriaNegocio);

        }

        [HttpGet("ObterDadosCategoria")]
        public async Task<CategoriaModel> Get([FromQuery] int id)
        {
            return await _categoriaNegocio.ObterUmaCategoria(id);
        }


    }
}
