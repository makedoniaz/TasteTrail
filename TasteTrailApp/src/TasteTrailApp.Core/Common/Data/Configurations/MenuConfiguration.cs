using MenuModel = TasteTrailApp.Core.Menu.Models.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TasteTrailApp.Core.Common.Data.Configuration;
public class MenuConfiguration : IEntityTypeConfiguration<MenuModel>
{
    public void Configure(EntityTypeBuilder<MenuModel> builder)
    {
        builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Description)
                .HasMaxLength(500);

            builder.HasMany(m => m.MenuItems)
                .WithOne(mi => mi.Menu)
                .HasForeignKey(mi => mi.MenuId);
    }
}