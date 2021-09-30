using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TryFi.Hotspot.Domain.Entities;

namespace TryFi.Hotspot.Data.Configurations
{
    public class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Upload).IsRequired();
            builder.Property(p => p.Download).IsRequired();


            builder
                .HasMany(p => p.Subscriptions)
                .WithOne(p => p.Plan)
                .HasForeignKey(p => p.PlanId);
        }
    }
}
