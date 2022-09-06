using CarLocadora.Entity;
using CarLocadora.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CarLocadora.Negocio.FormaPagamento
{
    public class FormaPagamentoNegocio : IFormaPagamentoNegocio
    {
        private readonly Context _context;
        public FormaPagamentoNegocio(Context context)
        {
            _context = context;
        }
        

        public async Task Alterar(FormaPagamentoModel pagamento)
        {
            pagamento.DataAlteracao = DateTime.Now;
            _context.Update(pagamento);
            await _context.SaveChangesAsync();

           

        }

        public async Task Inserir(FormaPagamentoModel pagamento)
        {
            pagamento.DataInclusao = DateTime.Now;
            await _context.AddAsync(pagamento);
            await _context.SaveChangesAsync();


        }

        public async Task <List<FormaPagamentoModel>> ObterLista()
        {
            return await _context.FormaPagamento.ToListAsync();
        }

        public async Task<FormaPagamentoModel> ObterUmPagamento(int id)
        {
            return await _context.FormaPagamento.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
