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
        [Display(Name = "Placa ")]
        [Required(ErrorMessage = "Campo é obrigatório")]
        [StringLength(8, ErrorMessage = "Maximo de 8 Caracteres")]
        public string Placa { get; set; }

        [Display(Name = "Chassi ")]
        [StringLength(100, ErrorMessage = "Campo Maximo de 100 Caracteres")]
        public string Chassi { get; set; }

        [Display(Name = "Marca ")]
        [Required(ErrorMessage = "Campo é obrigatório")]
        [StringLength(100, ErrorMessage = "Campo Maximo de 100 Caracteres")]
        public string Marca { get; set; }

        [Display(Name = "Modelo ")]
        [Required(ErrorMessage = "O Modelo é obrigatório")]
        public string Modelo { get; set; }

        [Display(Name = "Combustivel ")]
        [Required(ErrorMessage = "Campo é obrigatório")]
        [StringLength(100,  ErrorMessage = "Campo Maximo de 100 Caracteres")]
        public string combustivel;


        [Display(Name = "Cor ")]
        [Required(ErrorMessage = "Campo é obrigatório")]
        [StringLength(100, ErrorMessage = "Campo Maximo de 100 Caracteres")]
        public string Cor { get; set; }


        [Display(Name = "Opcionais ")]
        [StringLength(2000, ErrorMessage = "Campo Maximo de 2000 Caracteres")]
        public string Opcionais { get; set; }


        [Required(ErrorMessage = "Campo é Obrigatório")]
        public bool Ativo { get; set; }

        [Display(Name = "Data Inclusão ")]
        [Required(ErrorMessage = "Campo é Obrigatório")]
        public DateTime DataInclusao { get; set; }


        public DateTime DataAlteracao { get; set; }

        public int? CategoriaId { get; set; }

        public CategoriaModel? Categoria { get; set; }


    }
}




