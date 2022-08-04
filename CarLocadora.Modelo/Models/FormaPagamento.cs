using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Models.Models
{
    public class FormaPagamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Campo é Obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo é Obrigatório")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Campo Maximo de 150 Caracteres")]
        public string Descricao { get; set; }

        
        [Required(ErrorMessage = "Campo é Obrigatório")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Campo é Obrigatório")]
        public DateTime DataInclusao { get; set; }

        public DateTime DataAlteracao { get; set; }

    }
}
}
