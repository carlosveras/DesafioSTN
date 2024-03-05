using DesafioSTN.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioSTN.Infra.Data.EntitiesConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.NomeProduto).HasMaxLength(20).HasColumnType("varchar(20)");

            builder.Property(c => c.Valor).HasColumnType("decimal(10,2)");

        }
    }
}
