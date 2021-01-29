namespace DeliverIT.Domain
{
    public class Multa
    {
        public Multa(int quantidadeDias)
        {
            if (quantidadeDias > 0 && quantidadeDias <= 3)
            {
                this.PercentualMulta = 2;
                this.PercentialJurosDia = 0.1m;
            }
            else if (quantidadeDias > 3 && quantidadeDias <= 5)
            {
                this.PercentualMulta = 3;
                this.PercentialJurosDia = 0.2m;
            }
            else if (quantidadeDias > 5)
            {
                this.PercentualMulta = 5;
                this.PercentialJurosDia = 0.3m;
            }
        }

        public decimal PercentialJurosDia { get; }
        public decimal PercentualMulta { get; }
    }
}
