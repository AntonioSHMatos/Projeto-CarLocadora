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
        void Excluir(int Id);
        void Alterar(ManutencaoVeiculoModel manutencaoVeiculo);
        void Inserir(ManutencaoVeiculoModel manutencaoVeiculo);

        List<ManutencaoVeiculoModel> ObterLista();
        ManutencaoVeiculoModel ObterUmaManutencao(int id);
    }
}
