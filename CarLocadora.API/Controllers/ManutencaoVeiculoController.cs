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
        public void Post([FromBody] ManutencaoVeiculoModel veiculo)
        {
            _veiculo.Inserir(veiculo);

        }
        [HttpPut()]
        public void Put([FromBody] ManutencaoVeiculoModel veiculo)
        {
            _veiculo.Alterar(veiculo);

        }
        [HttpGet()]
        public List<ManutencaoVeiculoModel> Get()
        {
            return _veiculo.ObterLista();
        }
        [HttpGet("ObterUmaManutencao")]
        public ManutencaoVeiculoModel Get([FromQuery] int id)
        {
            return _veiculo.ObterUmaManutencao(id);
        }

        [HttpDelete()]
        public void Deletar([FromQuery] int Id)
        {
            _veiculo.Excluir(Id);
        }
    }
}

