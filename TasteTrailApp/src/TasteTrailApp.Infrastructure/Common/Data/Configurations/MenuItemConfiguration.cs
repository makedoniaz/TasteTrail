using MenuItemModel = TasteTrailApp.Core.MenuItem.Models.MenuItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TasteTrailApp.Infrastructure.Common.Data.Configuration;

public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItemModel>
{
    public void Configure(EntityTypeBuilder<MenuItemModel> builder)
    {
         builder.HasKey(mi => mi.Id);

            builder.Property(mi => mi.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(mi => mi.Description)
                .HasMaxLength(500);

            builder.Property(mi => mi.Price)
                .IsRequired();

            builder.Property(mi => mi.PopularityRate)
                .IsRequired();
    }
}