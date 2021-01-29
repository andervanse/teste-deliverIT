using System;
using System.Text;

namespace DeliverIT.Domain
{
    public class ContaPagar
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal ValorOriginal { get; set; }

        public bool EmAtraso
        {
            get
            {
                return DataPagamento > DataVencimento;
            }
        }



        private decimal _valorCorrigido;
        public decimal ValorCorrigido 
        { 
            get
            {
                decimal valorJurosMulta = CalcularJurosComMulta();
                return ValorOriginal + valorJurosMulta;
            }
        }

        private int _quantidadeDiasAtraso;
        public int QuantidadeDiasAtraso
        {
            get
            {
                return EmAtraso ? DataPagamento.Subtract(DataVencimento).Days : 0;
            }
        }

        private decimal _percentualMulta;
        public decimal PercentualMulta
        {
            get
            {
                Multa multa = new Multa(QuantidadeDiasAtraso);
                return multa.PercentualMulta;
            }
        }

        private decimal _percentualJurosDia;
        public decimal PercentualJurosDia
        {
            get
            {
                Multa multa = new Multa(QuantidadeDiasAtraso);
                return multa.PercentialJurosDia;
            }
        }

        private decimal _valorMulta;
        public decimal ValorMulta
        {
            get
            {
                Multa multa = new Multa(QuantidadeDiasAtraso);
                return (ValorOriginal / 100) * multa.PercentualMulta;
            }
        }

        private decimal _valorJurosDia;
        public decimal ValorJurosDia
        {
            get
            {
                int qtdeDias = QuantidadeDiasAtraso;
                Multa multa = new Multa(qtdeDias);
                decimal total = ValorOriginal * (decimal)Math.Pow(1 + (double)(multa.PercentialJurosDia / 100), qtdeDias);
                decimal juros = total - ValorOriginal;
                return  Math.Round(juros, 2);
            }
        }

        private decimal CalcularJurosComMulta()
        {
            return ValorJurosDia + ValorMulta;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Nome: '{Nome}', Valor Orig.: {ValorOriginal}, ");
            sb.Append($"Data Pagto.: {DataPagamento}, Data Venc.: {DataVencimento}, ");
            sb.Append($"% Multa: {PercentualMulta}, Valor Multa: {ValorMulta}, ");
            sb.Append($"% Juros Dia: {PercentualJurosDia}, Valor Juros Dia.: {ValorJurosDia},");
            sb.Append($"Valor Corrigido.: {ValorCorrigido} ");
            return sb.ToString();
        }
    }
}
