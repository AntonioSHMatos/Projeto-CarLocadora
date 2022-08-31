using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Models.Models
{
    public class FormaPagamentoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id é Obrigatório")]
        public int Id { get; set; }

        [Display(Name = "Descrição ")]
        [Required(ErrorMessage = "Descrição é Obrigatório")]
        [StringLength(150, ErrorMessage = "Campo Maximo de 150 Caracteres")]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "Campo é Obrigatório")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Campo é Obrigatório")]
        public DateTime DataInclusao { get; set; }

        public DateTime DataAlteracao { get; set; }
        
    }
}

