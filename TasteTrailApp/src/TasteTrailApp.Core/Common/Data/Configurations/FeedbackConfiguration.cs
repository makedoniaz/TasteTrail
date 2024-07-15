using FeedbackModel = TasteTrailApp.Core.Feedback.Models.Feedback;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TasteTrailApp.Core.Common.Data.Configuration;
public class FeedbackConfiguration : IEntityTypeConfiguration<FeedbackModel>
{
    public void Configure(EntityTypeBuilder<FeedbackModel> builder)
    {
        builder.HasKey(f => f.Id);

        // builder.HasOne(f => f.User)
        //     .WithMany(u => u.Feedbacks)
        //     .HasForeignKey(f => f.UserId)
        //     .OnDelete(DeleteBehavior.Restrict);

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
    }
}

