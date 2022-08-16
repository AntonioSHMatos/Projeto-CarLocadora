using CarLocadora.Models.Models;
using CarLocadora.Negocio.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioNegocio _usuario;
        public UsuarioController(IUsuarioNegocio usuario)
        {
            _usuario = usuario;
        }

        [HttpPost()]
        public void Post([FromBody] UsuarioModel usuario)
        {
            _usuario.Inserir(usuario);

        }
        [HttpPut()]
        public void Put([FromBody] UsuarioModel usuario)
        {
            _usuario.Alterar(usuario);

        }
        [HttpGet()]
        public List<UsuarioModel> Get()
        {
            return _usuario.ObterLista();
        }

    }
}
