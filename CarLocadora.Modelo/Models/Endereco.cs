using System.ComponentModel.DataAnnotations;

namespace CarLocadora.Models.Models
{
    public class Endereco  
    {
        [Required(ErrorMessage = "Campo é Obrigatório")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Campo minimo de 5 caracteres Maximo de 50 Caracteres")]
        public string Logradouro { get; set; } = "";

        [Required(ErrorMessage = "Campo é Obrigatório")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Campo minimo de 1 caracteres Maximo de 20 Caracteres")]
        public string Numero { get; set; } = "";

        
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Campo Maximo de 50 Caracteres")]
        public string Complemento  { get; set; }

        [Required(ErrorMessage = "Campo é Obrigatório")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Campo Maximo de 50 Caracteres")]
        public string Cidade { get; set; } = "";

        [Required(ErrorMessage = "Campo é Obrigatório")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Campo Maximo de 2 Caracteres")]
        public string Estado { get; set; } = "";
    }
}
