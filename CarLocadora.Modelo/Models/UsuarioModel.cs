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
        [Display(Name = "CPF")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "CPF é obrigatório")]
        [StringLength(14, ErrorMessage = "Campo máximo de 14 caracteres")]
        public string CPF { get; set; } = "";

        [Display(Name = "RG")]
        [Required(ErrorMessage = "RG é obrigatório")]
        [StringLength(50, ErrorMessage = "Campo máximo de 50 caracteres")]
        public string RG { get; set; } = "";


        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O nome completo é obrigatório")]
        [StringLength(150, ErrorMessage = "Este campo deve conter no mínimo 5 e no máximo 150 caracteres")]
        public string Nome { get; set; } = "";

        [Display(Name = "Data Nascimento Obrigatorio")]
        public DateTime DataNascimento { get; set; }


        [StringLength(15, ErrorMessage = "Telefone é Obrigatorio")]
        public string? Telefone { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Celular é Obrigatório")]
        [StringLength(15, ErrorMessage = "Campo Maximo de 15 Caracteres")]
        public string Celular { get; set; } = "";

        [Display(Name = "Senha ")]
        [StringLength(300, ErrorMessage = "Senha Maximo de 300 Caracteres")]
        public  string Senha { get; set; }

        [Display(Name = "Data Inclusão ")]
        [Required(ErrorMessage = "Data Inclusão é Obrigatório")]
        public DateTime DataInclusao { get; set; }

              

        public DateTime? DataAlteracao { get; set; }

        
    }
}
