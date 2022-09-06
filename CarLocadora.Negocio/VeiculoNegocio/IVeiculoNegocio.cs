using CarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.VeiculoNegocio.cs
{
    public interface IVeiculoNegocio
    {
        Task Alterar(VeiculoModel veiculo);
        Task Inserir(VeiculoModel veiculo);

        Task<List<VeiculoModel>> ObterLista();

        Task<VeiculoModel> ObterUmVeiculo(string placa);
    }
}
