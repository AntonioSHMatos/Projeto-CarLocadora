using CarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.ManutencaoVeiculo
{
    public interface IManutencaoVeiculoNegocio
    {
        Task Excluir(int Id);
        Task Alterar(ManutencaoVeiculoModel manutencaoVeiculo);
        Task Inserir(ManutencaoVeiculoModel manutencaoVeiculo);

        Task<List<ManutencaoVeiculoModel>> ObterLista();
        Task<ManutencaoVeiculoModel> ObterUmaManutencao(int id);
    }
}
