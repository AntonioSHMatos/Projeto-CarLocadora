using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarLocadora.Models.Models
{
    public class ClienteModel : Endereco
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "CPF é Obrigatório")]
        [StringLength(14, ErrorMessage = "Campo Maximo de 14 Caracteres")]
        public string CPF { get; set; } = "";

        
        [Required(ErrorMessage = "CNH é Obrigatório")]
        [StringLength(12, ErrorMessage = "Campo Maximo de 12 Caracteres")]
        public string CNH { get; set; } = "";

        [Display(Name = "Campo Completo")]
        [Required(ErrorMessage = "0 Nome Completo é Obrigatório")]
        [StringLength(150, ErrorMessage = "Este Campo deve ter no mínimo 5 e no maximo 150caracteres")]
        public string Nome { get; set; } = "";

        [Display(Name = "Campo Obrigatorio")]
        public DateTime DataNascimento { get; set; }


        [StringLength(15, MinimumLength = 0, ErrorMessage = "Campo Maximo de 15 Caracteres")]
        public string? Telefone { get; set; }


        [Required(ErrorMessage = "Campo é Obrigatório")]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "Campo Maximo de 15 Caracteres")]
        public string Celular { get; set; } = "";

        [Required(ErrorMessage = "Campo é Obrigatório")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Campo minimo de 5 caracteres Maximo de 50 Caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo é Obrigatório")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Campo minimo de 1 caracteres Maximo de 20 Caracteres")]
        public string Numero { get; set; }

        [StringLength(50, MinimumLength = 0, ErrorMessage = "Campo Maximo de 50 Caracteres")]
        public string Complemento { get; set; }


        [Required(ErrorMessage = "Campo é Obrigatório")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Campo Maximo de 50 Caracteres")]
        public string Cidade { get; set; } 

        [Required(ErrorMessage = "Campo é Obrigatório")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Campo Maximo de 2 Caracteres")]
        public string Estado { get; set; }

        [Display(Name = "Campo Obrigatório")]
        public DateTime DataInclusao { get; set; }


        [Display(Name = "Data Obrigatório")]
        public DateTime? DataAlteracao { get; set; }

        [Required(ErrorMessage = "Campo é Obrigatório")]
        public bool Ativo { get; set; }
    }
}
