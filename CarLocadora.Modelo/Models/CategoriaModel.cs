using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Models.Models
{
    public class CategoriaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Campo é Obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo é Obrigatório")]
        [StringLength(100, ErrorMessage = "Campo Maximo de 100 Caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo é Obrigatório")]
        public decimal ValorDiario  { get; set; }

        [Required(ErrorMessage = "Campo é Obrigatório")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Campo é Obrigatório")]
        public DateTime DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

    }
}
