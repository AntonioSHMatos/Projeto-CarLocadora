using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarLocadora.Models.Models
{
    public class Cliente : EnderecoModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "CPF é Obrigatório")]
        [StringLength(14, MinimumLength = 14 ,ErrorMessage = "Campo Maximo de 14 Caracteres")]
        public string CPF { get; set; } = "";

        
        [Required(ErrorMessage = "CNH é Obrigatório")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Campo Maximo de 12 Caracteres")]
        public string CNH { get; set; } = "";

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "0 Nome Completo é Obrigatório")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Este Campo deve ter no mínimo 5 e no maximo 150caracteres")]
        public string Nome { get; set; } = "";

        
        [StringLength(15, MinimumLength = 0, ErrorMessage = "Campo Maximo de 15 Caracteres")]
        public string? Telefone { get; set; }


        [Required(ErrorMessage = "Celular é Obrigatório")]
        public string Celular { get; set; } = "";

        [Display(Name = "Data Inclusão")]
        public DateTime DataInclusao { get; set; }


        [Display(Name = "Data Alteração")]
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; }
    }
}
