using Microsoft.EntityFrameworkCore;
using MRTestProject.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MRTestProject.Infastructure
{
    class ConfigureProduct : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(_ => _.ProductId);

            builder.Property(_ => _.Name).IsRequired()
                .HasMaxLength(100);

            builder.Property(_ => _.Description).HasMaxLength(1000);

            builder.Property(_ => _.Price).IsRequired();

            builder.Property(_ => _.CategoryId).IsRequired();
        }
    }
}
