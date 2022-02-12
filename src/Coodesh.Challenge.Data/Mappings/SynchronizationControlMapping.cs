using Coodesh.Challenge.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coodesh.Challenge.Data.Mappings
{
    public class SynchronizationControlMapping : IEntityTypeConfiguration<SynchronizationControl>
    {
        public void Configure(EntityTypeBuilder<SynchronizationControl> builder)
        {
            builder.ToTable("SynchronizationControl");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.ArticlesCount)
                .IsRequired();

            builder.Property(p => p.SynchronizedArticles)
                .IsRequired();

            builder.Property(p => p.CreateAt)
                .IsRequired();
        }
    }
}