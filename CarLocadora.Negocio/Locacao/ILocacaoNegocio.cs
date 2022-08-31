using CarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.Locacao
{
    public interface ILocacaoNegocio 
    {

        List<LocacaoModel> ObterLista();

        void Alterar(LocacaoModel locacao);
        void Inserir(LocacaoModel locacao);

        LocacaoModel ObterUmaLocacao(int id);
    }

}
