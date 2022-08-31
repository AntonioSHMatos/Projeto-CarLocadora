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
        private readonly IClienteNegocio _cliente;
        public ClienteController(IClienteNegocio cliente)
        {
            _cliente = cliente;
        }

        [HttpGet]
        public List<ClienteModel> Get()
        {
            return _cliente.ObterLista();
        }


        [HttpPost()]
        public void Post([FromBody] ClienteModel cliente)
        {
            _cliente.Inserir(cliente);
                       
        }
        [HttpPut()]
        public void Put([FromBody] ClienteModel cliente)
        {
            _cliente.Alterar(cliente);

        }
        [HttpGet("ObterUmCliente")]
        public ClienteModel Get([FromQuery] string cpf)
        {
            return _cliente.ObterUmCliente(cpf);
        }
    }
}
