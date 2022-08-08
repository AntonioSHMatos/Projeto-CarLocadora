using CarLocadora.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.FormaPagamento
{
    public class FormaPagamentoNegocio : IFormaPagamentoNegocio
    {
        private readonly Context _context;
        public FormaPagamentoNegocio(Context context)
        {
            _context = context;
        }
        public void Alterar(FormaPagamentoNegocio pagamento)
        {
            _context.Update(pagamento);
            _context.SaveChangesAsync();
        }

        public void Inserir(FormaPagamentoNegocio pagamento)
        {
            _context.AddAsync(pagamento);
            _context.SaveChangesAsync();
        }

        
    }
}
