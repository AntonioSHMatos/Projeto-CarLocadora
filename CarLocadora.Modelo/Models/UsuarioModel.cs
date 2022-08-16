using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Models.Models
{
    public class UsuarioModel : Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Campo é obrigatório")]
        [StringLength(14, ErrorMessage = "Campo máximo de 14 caracteres")]
        public string CPF { get; set; } = "";

        [Required(ErrorMessage = "Campo é obrigatório")]
        [StringLength(50, ErrorMessage = "Campo máximo de 50 caracteres")]
        public string RG { get; set; } = "";

        [Display(Name = "Campo Completo")]
        [Required(ErrorMessage = "O nome completo é obrigatório")]
        [StringLength(150, ErrorMessage = "Este campo deve conter no mínimo 5 e no máximo 150 caracteres")]
        public string Nome { get; set; } = "";

        [Display(Name = "Campo Obrigatorio")]
        public DateTime DataNascimento { get; set; }


        [StringLength(15, ErrorMessage = "Campo Maximo de 15 Caracteres")]
        public string? Telefone { get; set; }


        [Required(ErrorMessage = "Campo é Obrigatório")]
        [StringLength(15, ErrorMessage = "Campo Maximo de 15 Caracteres")]
        public string Celular { get; set; } = "";

        [Required(ErrorMessage = "Campo é Obrigatório")]
        [StringLength(50, ErrorMessage = "Campo minimo de 5 caracteres Maximo de 50 Caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo é Obrigatório")]
        [StringLength(20, ErrorMessage = "Campo minimo de 1 caracteres Maximo de 20 Caracteres")]
        public string Numero { get; set; }

        [StringLength(50, ErrorMessage = "Campo Maximo de 50 Caracteres")]
        public string Complemento { get; set; }


        [Required(ErrorMessage = "Campo é Obrigatório")]
        [StringLength(50, ErrorMessage = "Campo Maximo de 50 Caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo é Obrigatório")]
        [StringLength(2, ErrorMessage = "Campo Maximo de 2 Caracteres")]
        public string Estado { get; set; }

        [StringLength(300, ErrorMessage = "Campo Maximo de 300 Caracteres")]
        public  string Senha { get; set; }

        
        [Required(ErrorMessage = "Campo é Obrigatório")]
        public DateTime DataInclusao { get; set; }


        
        [Required(ErrorMessage = "Campo é Obrigatório")]
        public DateTime? DataAlteracao { get; set; }

        
    }
}
