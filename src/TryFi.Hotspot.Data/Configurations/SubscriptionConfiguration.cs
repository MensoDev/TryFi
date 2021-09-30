using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TryFi.Hotspot.Domain.Entities;

namespace TryFi.Hotspot.Data.Configurations
{
    internal class SubscriptionConfiguration :
        IEntityTypeConfiguration<Subscription>,
        IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PersonId).IsRequired();
            builder.Property(p => p.PlanId).IsRequired();

            builder
                .HasOne(p => p.Login)
                .WithOne(p => p.Subscription)
                .HasForeignKey<Login>(p => p.SubscriptionId)
                .HasForeignKey<Subscription>(p => p.LoginId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(p => p.Plan)
                .WithMany(p => p.Subscriptions)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.UserName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.MacAddress)
                .IsRequired()
                .HasMaxLength(12);
        }
    }
}
