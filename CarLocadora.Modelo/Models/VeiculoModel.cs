using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Models.Models
{
    public class VeiculoModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Campo é obrigatório")]
        public string Placa { get; set; }


        [StringLength(100, ErrorMessage = "Campo Maximo de 100 Caracteres")]
        public string Chassi { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        [StringLength(100, ErrorMessage = "Campo Maximo de 100 Caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O Modelo é obrigatório")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        [StringLength(100,  ErrorMessage = "Campo Maximo de 100 Caracteres")]
        public string combustivel;



        [Required(ErrorMessage = "Campo é obrigatório")]
        [StringLength(100, ErrorMessage = "Campo Maximo de 100 Caracteres")]
        public string Cor { get; set; }



        [StringLength(2000, ErrorMessage = "Campo Maximo de 2000 Caracteres")]
        public string Opcionais { get; set; }

        [Required(ErrorMessage = "Campo é Obrigatório")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Campo é Obrigatório")]
        public DateTime DataInclusao { get; set; }

        public DateTime DataAlteracao { get; set; }


    }
}




