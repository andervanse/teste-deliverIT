using DeliverIT.Domain;
using System;
using Xunit;

namespace DeliverIT.Test
{
    public class ContaPagarTest
    {
        /*
           Dias em atraso     Multa    Juros/dia
           até 3 dias            2%         0,1%
           superior a 3 dias     3%         0,2%
           superior a 5 dias     5%         0,3%
        */

        [Theory]
        [InlineData("2021-05-01", "2021-05-01", 100, 0.00)]
        [InlineData("2021-05-01", "2021-05-03", 100, 0.20)]
        [InlineData("2021-05-01", "2021-05-04", 100, 0.30)]
        [InlineData("2021-05-01", "2021-05-05", 100, 0.80)]
        [InlineData("2021-05-01", "2021-05-06", 100, 1.00)]
        [InlineData("2021-05-01", "2021-05-07", 100, 1.81)]
        [InlineData("2021-05-01", "2021-05-17", 100, 4.91)]
        public void Valor_Juros_Por_Dia(string dataVencimento, string dataPagamento, decimal valorOriginal, decimal expected)
        {
            ContaPagar cp = new ContaPagar
            {
                Nome = "Conta Teste 2",
                DataPagamento = DateTime.Parse(dataPagamento),
                DataVencimento = DateTime.Parse(dataVencimento),
                ValorOriginal = valorOriginal
            };

            Assert.Equal(expected, cp.ValorJurosDia);
        }

        [Theory]
        [InlineData("2021-05-01", "2021-05-01", 100, 0.00)]
        [InlineData("2021-05-01", "2021-05-03", 100, 2.00)]
        [InlineData("2021-05-01", "2021-05-04", 100, 2.00)]
        [InlineData("2021-05-01", "2021-05-05", 100, 3.00)]
        [InlineData("2021-05-01", "2021-05-06", 100, 3.00)]
        [InlineData("2021-05-01", "2021-05-07", 100, 5.00)]
        [InlineData("2021-05-01", "2021-05-17", 100, 5.00)]
        public void Valor_Multa(string dataVencimento, string dataPagamento, decimal valorOriginal, decimal expected)
        {
            ContaPagar cp = new ContaPagar
            {
                Nome = "Conta Teste 3",
                DataPagamento = DateTime.Parse(dataPagamento),
                DataVencimento = DateTime.Parse(dataVencimento),
                ValorOriginal = valorOriginal
            };

            Assert.Equal(expected, cp.ValorMulta);
        }

        [Theory]
        [InlineData("2021-05-01", "2021-05-01", 100, 100.00)]
        [InlineData("2021-05-01", "2021-05-03", 100, 102.20)]
        [InlineData("2021-05-01", "2021-05-04", 100, 102.30)]
        [InlineData("2021-05-01", "2021-05-05", 100, 103.80)]
        [InlineData("2021-05-01", "2021-05-06", 100, 104.00)]
        [InlineData("2021-05-01", "2021-05-07", 100, 106.81)]
        [InlineData("2021-05-01", "2021-05-17", 100, 109.91)]
        public void Valor_Corrigido(string dataVencimento, string dataPagamento, decimal valorOriginal, decimal expected)
        {
            ContaPagar cp = new ContaPagar
            {
                Nome = "Conta Teste 4",
                DataPagamento = DateTime.Parse(dataPagamento),
                DataVencimento = DateTime.Parse(dataVencimento),
                ValorOriginal = valorOriginal
            };

            Assert.Equal(expected, cp.ValorCorrigido);
        }
    }
}
