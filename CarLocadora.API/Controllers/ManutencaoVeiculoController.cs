using CarLocadora.Models.Models;
using CarLocadora.Negocio.ManutencaoVeiculo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ManutencaoVeiculo : ControllerBase
    {
        private readonly IManutencaoVeiculoNegocio _veiculo;
        public ManutencaoVeiculo(IManutencaoVeiculoNegocio veiculo)
        {
            _veiculo = veiculo;
        }

        [HttpPost()]
        public async Task Post([FromBody] ManutencaoVeiculoModel veiculo)
        {
            await _veiculo.Inserir(veiculo);

        }
        [HttpPut()]
        public async Task Put([FromBody] ManutencaoVeiculoModel veiculo)
        {
            await _veiculo.Alterar(veiculo);

        }
        [HttpGet()]
        public async Task<List<ManutencaoVeiculoModel>> Get()
        {
            return await  _veiculo.ObterLista();
        }
        [HttpGet("ObterUmaManutencao")]
        public async Task<ManutencaoVeiculoModel> Get([FromQuery] int id)
        {
            return await _veiculo.ObterUmaManutencao(id);
        }

        [HttpDelete()]
        public async Task Deletar([FromQuery] int Id)
        {
            await _veiculo.Excluir(Id);
        }
    }
}

