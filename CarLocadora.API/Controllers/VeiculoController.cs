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
        public async Task Post([FromBody] VeiculoModel veiculo)
        {
            await _veiculo.Inserir(veiculo);

        }
        [HttpPut()]
        public async Task Put([FromBody] VeiculoModel veiculo)
        {
            await _veiculo.Alterar(veiculo);

        }
        [HttpGet()]
        public async Task<List<VeiculoModel>> Get()
        {
            return await _veiculo.ObterLista();
        }
        [HttpGet("ObterUmVeiculo")]
        public async Task<VeiculoModel> Get([FromQuery] string placa)
        {
            return await _veiculo.ObterUmVeiculo(placa);
        }

    }
}
