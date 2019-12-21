using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRTestProject.Common;

namespace MRTestProject.Infastructure
{
    class ConfigureCategory : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(_ => _.CategoryId);

            builder.HasAlternateKey(_ => _.Name);

            builder.Property(_ => _.Name).HasMaxLength(100);
        }
    }
}

