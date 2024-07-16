using VenuePhotosModel = TasteTrailApp.Core.VenuePhotos.Models.VenuePhotos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TasteTrailApp.Infrastructure.Common.Data.Configuration;
public class VenuePhotosConfiguration : IEntityTypeConfiguration<VenuePhotosModel>
{
    public void Configure(EntityTypeBuilder<VenuePhotosModel> builder)
    {
        builder.HasKey(vp => vp.Id);

            builder.Property(vp => vp.PhotoUrlPath)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(vp => vp.Venue)
                .WithMany(v => v.Photos)
                .HasForeignKey(vp => vp.VenueId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}