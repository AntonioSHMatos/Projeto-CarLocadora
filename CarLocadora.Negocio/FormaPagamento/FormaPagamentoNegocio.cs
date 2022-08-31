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
            pagamento.DataAlteracao = DateTime.Now;
            _context.Update(pagamento);
            _context.SaveChanges();

           

        }

        public void Inserir(FormaPagamentoModel pagamento)
        {
            pagamento.DataInclusao = DateTime.Now;
            _context.AddAsync(pagamento);
            _context.SaveChanges();


        }

        public List<FormaPagamentoModel> ObterLista()
        {
            return _context.FormaPagamento.ToList();
        }

        public FormaPagamentoModel ObterUmPagamento(int id)
        {
            return _context.FormaPagamento.SingleOrDefault(x => x.Id == id);
        }
    }
}
