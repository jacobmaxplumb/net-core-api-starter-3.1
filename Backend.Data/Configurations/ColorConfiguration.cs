using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Backend.Core.Models;

namespace Backend.Data.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Id)
                .UseIdentityColumn();
                
            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .ToTable("Colors");
        }
    }
}