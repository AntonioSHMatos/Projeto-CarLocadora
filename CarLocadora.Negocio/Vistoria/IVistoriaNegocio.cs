using CarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.Vistoria
{
    public interface IVistoriaNegocio
    {
        Task<List<VistoriaModel>> ObterLista();

        Task Alterar(VistoriaModel vistoria);
        Task Inserir(VistoriaModel vistoria);

        Task<VistoriaModel> ObterUmaVistoria(int id);
    }
}
