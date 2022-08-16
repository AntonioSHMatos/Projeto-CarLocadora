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
        void Alterar(VeiculoModel veiculo);
        void Inserir(VeiculoModel veiculo);

        List<VeiculoModel> ObterLista();

    }
}
