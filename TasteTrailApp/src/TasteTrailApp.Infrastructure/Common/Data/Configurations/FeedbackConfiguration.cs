using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TasteTrailApp.Core.Feedbacks.Models;

namespace TasteTrailApp.Infrastructure.Common.Data.Configurations;

public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.HasKey(f => f.Id); 

        builder.HasOne(f => f.Venue)
            .WithMany(v => v.Feedbacks)
            .HasForeignKey(f => f.VenueId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(f => f.Text)
            .IsRequired();

        builder.Property(f => f.Rating)
            .IsRequired();

        builder.Property(f => f.CreationDate)
            .IsRequired();

        
        builder
            .HasOne(f => f.User)
            .WithMany(u => u.Feedbacks)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

