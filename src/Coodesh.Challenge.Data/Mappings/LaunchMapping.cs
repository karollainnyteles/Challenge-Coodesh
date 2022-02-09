using Coodesh.Challenge.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coodesh.Challenge.Data.Mappings
{
    public class LaunchMapping : IEntityTypeConfiguration<Launch>
    {
        public void Configure(EntityTypeBuilder<Launch> builder)
        {
            builder.ToTable("Launch");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Provider)
                .IsRequired()
                .HasColumnType("varchar(200)");
        }
    }
}