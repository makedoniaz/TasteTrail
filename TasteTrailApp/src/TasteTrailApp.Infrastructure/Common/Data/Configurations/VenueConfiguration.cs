using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TasteTrailApp.Core.Venues.Models;

namespace TasteTrailApp.Infrastructure.Common.Data.Configurations;
public class VenueConfiguration : IEntityTypeConfiguration<Venue>
{
    public void Configure(EntityTypeBuilder<Venue> builder)
    {
        builder.HasKey(v => v.Id);

        builder.Property(v => v.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(v => v.Address)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(v => v.Description)
            .HasMaxLength(1000);

        builder.Property(v => v.ContactNumber)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(v => v.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(v => v.LogoUrlPath)
            .HasMaxLength(500);

        builder.Property(v => v.AveragePrice)
            .IsRequired();

        builder.Property(v => v.OverallRating)
            .IsRequired();

        builder.HasMany(v => v.Menus)
            .WithOne(m => m.Venue)
            .HasForeignKey(m => m.VenueId);

        builder.HasMany(v => v.Photos)
            .WithOne(p => p.Venue)
            .HasForeignKey(p => p.VenueId);

        builder.HasMany(v => v.Feedbacks)
            .WithOne(f => f.Venue)
            .HasForeignKey(f => f.VenueId);

        builder
            .HasOne(v => v.User)
            .WithMany(u => u.Venues)
            .HasForeignKey(v => v.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}