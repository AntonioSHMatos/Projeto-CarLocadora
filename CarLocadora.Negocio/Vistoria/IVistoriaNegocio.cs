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
        List<VistoriaModel> ObterLista();

        void Alterar(VistoriaModel vistoria);
        void Inserir(VistoriaModel vistoria);

        VistoriaModel ObterUmaVistoria(int id);
    }
}
