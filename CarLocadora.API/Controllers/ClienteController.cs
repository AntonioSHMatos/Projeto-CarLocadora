using CarLocadora.Models.Models;
using CarLocadora.Negocio.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteNegocio _clienteNegocio;
        public ClienteController(IClienteNegocio cliente)
        {
            _clienteNegocio = cliente;
        }

        [HttpGet]
        public List<ClienteModel> Get()
        {
            return _clienteNegocio.ObterLista();
        }


        [HttpPost()]
        public void Post([FromBody] ClienteModel cliente)
        {
            _clienteNegocio.Inserir(cliente);
                       
        }
        [HttpPut()]
        public void Put([FromBody] ClienteModel cliente)
        {
            _clienteNegocio.Alterar(cliente);

        }
        [HttpGet("ObterUmCliente")]
        public ClienteModel Get([FromQuery] string cpf)
        {
            return _clienteNegocio.ObterUmCliente(cpf);
        }

        [HttpGet("ObterListaEnviarEmail")]
        public  List<ClienteModel> ObterListaEnviarEmail()
        {
            return _clienteNegocio.ObterListaEnviarEmail();

        }

    }
}
