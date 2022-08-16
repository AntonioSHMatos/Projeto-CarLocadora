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
        void Alterar(FormaPagamentoModel pagamento);
        void Inserir(FormaPagamentoModel pagamento);
        List<FormaPagamentoModel> ObterLista();

    }
}
