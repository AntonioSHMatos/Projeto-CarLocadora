using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.FormaPagamento
{
    public interface IFormaPagamentoNegocio
    {       
        void Alterar(FormaPagamentoNegocio pagamento);
        void Inserir(FormaPagamentoNegocio pagamento);

    }
}
