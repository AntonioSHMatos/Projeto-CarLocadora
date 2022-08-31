using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Models.Models
{
    public class VistoriaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id é Obrigatório")]
        public int Id { get; set; }


        [Display(Name = "Locação ")]
        [Required(ErrorMessage = "Locação é Obrigatório")]       
        public int LocacaoId { get; set; }
        public LocacaoModel? Locacao { get; set; }


        [Display(Name = "Km Saìda")]
        [Required(ErrorMessage = "Km é Obrigatório")]
        public long KmSaida { get; set; }


        [Display(Name = "Combustivel De Saida")]
        [Required(ErrorMessage = "Combustivel é Obrigatório")]
        [StringLength(50, MinimumLength =5, ErrorMessage = "Campo Minímo 5 e Maximo de 50 Caracteres")]
        public string CombustivelSaida { get; set; }


        [Display(Name = "Observação Saída")]
        [StringLength(2000, ErrorMessage = "Campo Maximo de 2000 Caracteres")]
        public string? ObservacaoSaida { get; set; }


        [Display(Name = "Data Hora Retirada Patio")]
        [Required(ErrorMessage = " Data Hora Retirada Patio Obrigatório")]
        public DateTime DataHoraRetiradaPatio { get; set; }


        [Display(Name = "Km De Entrada")]        
        public long ? KmEntrada { get; set; }


        [Display(Name = "Combustivel De Entrada")]
        [StringLength(50, ErrorMessage = "Campo Maximo de 50 Caracteres")]
        public string ? CombustivelEntrada { get; set; }


        [Display(Name = "Observação De Entrada")]
        [StringLength(2000, ErrorMessage = "Campo Maximo de 2000 Caracteres")]
        public string? ObservacaoEntrada { get; set; }


        [Display(Name = "Data Hora Devolução Patio")]
        public DateTime? DataHoraDevolucaoPatio { get; set; }


        [Display(Name = "Data De Inclusão")]
        [Required(ErrorMessage = " Data Inclusão Obrigatório")]
        public DateTime DataInclusao { get; set; }


        [Display(Name = "Data De Alteração")]
        public DateTime? DataAlteracao { get; set; }

    }
}
