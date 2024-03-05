using DesafioSTN.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioSTN.Infra.Data.EntitiesConfiguration
{
    public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(c => c.IdPedido).HasColumnType("int");

            builder.Property(c => c.IdProduto).HasColumnType("int");

            builder.Property(c => c.Quantidade).HasColumnType("int");

            builder.HasOne(ip => ip.Pedido)                      
                             .WithMany(p => p.ItensPedido)      
                             .HasForeignKey(ip => ip.IdPedido) 
                             .IsRequired();

            builder.HasOne(ip => ip.Produto)
                            .WithMany()
                            .HasForeignKey(ip => ip.IdProduto)
                            .IsRequired();
        }
    }
}
