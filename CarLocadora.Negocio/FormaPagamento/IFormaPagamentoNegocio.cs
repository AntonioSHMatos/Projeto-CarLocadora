using CarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.FormaPagamento
{
    public interface IFormaPagamentoNegocio
    {       
        Task Alterar(FormaPagamentoModel pagamento);
        Task Inserir(FormaPagamentoModel pagamento);
        Task <List<FormaPagamentoModel>> ObterLista();

        Task <FormaPagamentoModel> ObterUmPagamento(int id);

    }
}
