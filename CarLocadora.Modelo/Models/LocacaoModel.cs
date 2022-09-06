using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Models.Models
{
    public class LocacaoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id é Obrigatório")]       
        public int Id { get; set; }


        [Display(Name = "CPF Do Cliente")]
        [Required(ErrorMessage = "CPF é Obrigatório")]
        [StringLength(14, ErrorMessage = "Campo Maximo de 14 Caracteres")]
        public string ClienteCPF { get; set; }
        public virtual ClienteModel? Cliente  { get; set; }


        [Display(Name = "Forma de Pagamento")]
        [Required(ErrorMessage = "Forma De Pagamento é Obrigatório")]
        public int FormaPagamentoId { get; set; }
        public FormaPagamentoModel? FormaPagamento { get; set; }

             


        [Display(Name = "Data/Hora Reserva")]
        [Required(ErrorMessage = "Data Hora Reserva é Obrigatório")]
        public DateTime DataHoraReserva { get; set; }

        [Display(Name = "Data Hora Retirada Prevista")]
        [Required(ErrorMessage = "Data Hora Reserva é Obrigatório")]
        public DateTime DataHoraRetiradaPrevista { get; set; }

        [Display(Name = "Data Hora Devolução Prevista")]
        [Required(ErrorMessage = "Data Hora Devolução é Obrigatório")]
        public DateTime DataHoraDevolucaoPrevista { get; set; }

        [Display(Name = "Veiculo")]
        [StringLength(8, ErrorMessage = "Maximo de 8 Caracteres")]
        public string? VeiculoPlaca { get; set; }
        public VeiculoModel? Veiculo { get; set; }


        [Display(Name = "Data De Inclusão")]
        [Required(ErrorMessage = "Data Inclusão é Obrigatório")]
        public DateTime DataInclusao { get; set; }


        [Display(Name = "Data  De Alteração")]
        public DateTime? DataAlteracao { get; set; }
    }
}
