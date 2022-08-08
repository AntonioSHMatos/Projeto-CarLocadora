using CarLocadora.Models.Models;
using CarLocadora.Negocio.Categoria;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaNegocio _categoriaNegocio;

        public CategoriaController(ICategoriaNegocio categoriaNegocio)
        {
            _categoriaNegocio = categoriaNegocio;
        }
        
        [HttpDelete()]
        public void Deletar([FromQuery]int Id)
        {
            _categoriaNegocio.Excluir(Id);
        }

        [HttpGet]
        public List<CategoriaModel> Get()
        {
            return _categoriaNegocio.ObterLista();
        }


        [HttpPost()]
        public void Post([FromBody] CategoriaModel categoriaNegocio)
        {
            _categoriaNegocio.Inserir(categoriaNegocio);

        }
        [HttpPut()]
        public void Put([FromBody] CategoriaModel categoriaNegocio)
        {
            _categoriaNegocio.Alterar(categoriaNegocio);

        }



    }
}
