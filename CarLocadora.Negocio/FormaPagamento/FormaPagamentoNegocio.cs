using CarLocadora.Entity;
using CarLocadora.Models.Models;

namespace CarLocadora.Negocio.FormaPagamento
{
    public class FormaPagamentoNegocio : IFormaPagamentoNegocio
    {
        private readonly Context _context;
        public FormaPagamentoNegocio(Context context)
        {
            _context = context;
        }
        

        public void Alterar(FormaPagamentoModel pagamento)
        {
            _context.Update(pagamento);
            _context.SaveChangesAsync();
        }

        public void Inserir(FormaPagamentoModel pagamento)
        {
            _context.AddAsync(pagamento);
            _context.SaveChangesAsync();
        }

        public List<FormaPagamentoModel> ObterLista()
        {
            return _context.FormaPagamento.ToList();
        }
    }
}
