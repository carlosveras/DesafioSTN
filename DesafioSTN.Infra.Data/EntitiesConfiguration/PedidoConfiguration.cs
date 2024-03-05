using DesafioSTN.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioSTN.Infra.Data.EntitiesConfiguration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(c => c.NomeCliente).HasMaxLength(60).HasColumnType("varchar(60)");

            builder.Property(c => c.EmailCliente).HasMaxLength(60).HasColumnType("varchar(60)");

            builder.Property(c => c.DataCriacao).HasColumnType("datetime");

            builder.Property(c => c.Pago).HasColumnType("BIT");

        }
    }
}
