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

        Task<List<LocacaoModel>> ObterLista();

        Task Alterar(LocacaoModel locacao);
        Task Inserir(LocacaoModel locacao);

        Task<LocacaoModel> ObterUmaLocacao(int id);
    }

}
