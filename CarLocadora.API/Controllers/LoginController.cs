
using CarLocadora.Models.Models;
using CarLocadora.Negocio.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginNegocio _loginNegocio;


        public LoginController(ILoginNegocio loginNegocio)
        {
            _loginNegocio = loginNegocio;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<LoginRespostaModel>> Login([FromBody] LoginRequisicaoModel loginRequisicaoModel)
        {
            return Ok(await _loginNegocio.Login(loginRequisicaoModel));
        }

    }
}
