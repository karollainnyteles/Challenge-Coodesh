using Coodesh.Challenge.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coodesh.Challenge.Data.Mappings
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Article");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(p => p.Url)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(p => p.ImageUrl)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(p => p.NewsSite)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(p => p.Summary)
                .HasColumnType("varchar(600)");

            builder.Property(p => p.PublishedAt)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.UpdatedAt)
                .HasColumnType("datetime");

            builder.HasMany(p => p.Launches)
                .WithOne(p => p.Article)
                .HasForeignKey(p => p.ArticleId);

            builder.HasMany(p => p.Events)
                .WithOne(p => p.Article)
                .HasForeignKey(p => p.ArticleId);

            builder.Navigation(a => a.Events).AutoInclude();
            builder.Navigation(a => a.Launches).AutoInclude();
        }
    }
}