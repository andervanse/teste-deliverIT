using DeliverIT.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliverIT.Data.Mappings
{
    public class ContaPagarConfiguration: IEntityTypeConfiguration<ContaPagar>
    {
        public void Configure(EntityTypeBuilder<ContaPagar> builder)
        {
            builder.ToTable("ContasPagar");

            builder.HasKey(cp => cp.Id);

            builder.Property(cp => cp.Nome).HasMaxLength(200).IsRequired();

            builder.Property(cp => cp.DataPagamento).IsRequired();

            builder.Property(cp => cp.DataVencimento).IsRequired();

            builder.Property(cp => cp.ValorOriginal).IsRequired();

            builder.Property(cp => cp.ValorCorrigido)
                .HasField("_valorCorrigido")
                .UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction)
                .IsRequired();

            builder.Property(cp => cp.QuantidadeDiasAtraso)
                .HasField("_quantidadeDiasAtraso")
                .UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction)
                .IsRequired();

            builder.Property(cp => cp.PercentualMulta)
                .HasField("_percentualMulta")
                .UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction)
                .IsRequired();

            builder.Property(cp => cp.PercentualJurosDia)
                .HasField("_percentualJurosDia")
                .UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction)
                .IsRequired();

            builder.Property(cp => cp.ValorJurosDia)
                .HasField("_valorJurosDia")
                .UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction)
                .IsRequired();

            builder.Property(cp => cp.ValorMulta)
                .HasField("_valorMulta")
                .UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction)
                .IsRequired();

            builder.Ignore(cp => cp.EmAtraso);
        }
    }
}
