using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TasteTrailApp.Core.VenuesPhotos.Models;

namespace TasteTrailApp.Infrastructure.Common.Data.Configurations;
public class VenuePhotosConfiguration : IEntityTypeConfiguration<VenuePhotos>
{
    public void Configure(EntityTypeBuilder<VenuePhotos> builder)
    {
        builder.HasKey(vp => vp.Id);

        builder.Property(vp => vp.PhotoUrlPath)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasOne(vp => vp.Venue)
            .WithMany(v => v.Photos)
            .HasForeignKey(vp => vp.VenueId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}