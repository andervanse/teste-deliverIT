
using System;
using System.ComponentModel.DataAnnotations;

namespace DeliverIT.Application.DTO
{
    public class ContaPagar
    {
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 3)]
        [Required(ErrorMessage = "Nome Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data de Vencimento Obrigatória")]
        [DataType(DataType.Date)]
        public DateTime? DataVencimento { get; set; }

        [Required(ErrorMessage = "Data de Pagamento Obrigatória")]
        [DataType(DataType.Date)]
        public DateTime? DataPagamento { get; set; }

        [Required(ErrorMessage = "Valor Original Obrigatório")]
        [Range(0, int.MaxValue)]
        public decimal? ValorOriginal { get; set; }
        
        public bool EmAtraso { get; set; }
        public decimal ValorCorrigido { get; set; }
        public int QuantidadeDiasAtraso { get; set; }
        public decimal PercentualMulta { get; set; }
        public decimal PercentualJurosDia { get; set; }
        public decimal ValorMulta { get; set; }
        public decimal ValorJurosDia { get; set; }
    }

}
