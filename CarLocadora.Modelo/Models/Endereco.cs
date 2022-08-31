using System.ComponentModel.DataAnnotations;

namespace CarLocadora.Models.Models
{
    public class Endereco  
    {
        [Required(ErrorMessage = "Logradouro é Obrigatório")]
        [StringLength(50, ErrorMessage = "Campo minimo de 5 caracteres Maximo de 50 Caracteres")]
        public string Logradouro { get; set; } = "";

        [Required(ErrorMessage = "Numero é Obrigatório")]
        [StringLength(20, ErrorMessage = "Campo minimo de 1 caracteres Maximo de 20 Caracteres")]
        public string Numero { get; set; } = "";

        
        [StringLength(50, ErrorMessage = "Complemento Maximo de 50 Caracteres")]
        public string Complemento  { get; set; }

        [Required(ErrorMessage = "Cidade é Obrigatório")]
        [StringLength(50, ErrorMessage = "Campo Maximo de 50 Caracteres")]
        public string Cidade { get; set; } = "";

        [Required(ErrorMessage = "Estado é Obrigatório")]
        [StringLength(2, ErrorMessage = "Campo Maximo de 2 Caracteres")]
        public string Estado { get; set; } = "";
    }
}
