using CarLocadora.Models.Models;
using CarLocadora.Negocio.VeiculoNegocio.cs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoNegocio _veiculo;
        public VeiculoController(IVeiculoNegocio veiculo)
        {
            _veiculo = veiculo;
        }

        [HttpPost()]
        public void Post([FromBody] VeiculoModel veiculo)
        {
            _veiculo.Inserir(veiculo);

        }
        [HttpPut()]
        public void Put([FromBody] VeiculoModel veiculo)
        {
            _veiculo.Alterar(veiculo);

        }
        [HttpGet()]
        public List<VeiculoModel> Get()
        {
            return _veiculo.ObterLista();
        }
        [HttpGet("ObterUmVeiculo")]
        public VeiculoModel Get([FromQuery] string placa)
        {
            return _veiculo.ObterUmVeiculo(placa);
        }





    }
}
