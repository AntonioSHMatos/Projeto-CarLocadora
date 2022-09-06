using CarLocadora.Models.Models;
using CarLocadora.Negocio.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioNegocio _usuario;
        public UsuarioController(IUsuarioNegocio usuario)
        {
            _usuario = usuario;
        }

        [HttpPost()]
        public async Task Post([FromBody] UsuarioModel usuario)
        {
            await _usuario.Inserir(usuario);

        }

        [HttpPut()]
        public async Task Put([FromBody] UsuarioModel usuario)
        {
            await _usuario.Alterar(usuario);

        }

        [HttpGet()]
        public async Task<List<UsuarioModel>> Get()
        {
            return await _usuario.ObterLista();
        }

        [HttpGet("ObterUmUsuario")]
        public async Task<UsuarioModel> Get([FromQuery] string cpf)
        {
            return await _usuario.ObterUmUsuario(cpf);
        }
    }
}
