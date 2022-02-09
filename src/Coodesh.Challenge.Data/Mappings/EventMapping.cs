using Coodesh.Challenge.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coodesh.Challenge.Data.Mappings
{
    public class EventMapping : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Event");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Provider)
                .IsRequired()
                .HasColumnType("varchar(200)");
        }
    }
}