using Microsoft.EntityFrameworkCore;
using TasteTrailApp.Infrastructure.Common.Data.Configurations;

// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using MenuItemModel = TasteTrailApp.Core.MenuItems.Models.MenuItem;
using TasteTrailApp.Core.Venues.Models;
using TasteTrailApp.Core.VenuesPhotos.Models;
using TasteTrailApp.Core.Feedbacks.Models;
using TasteTrailApp.Core.Menus.Models;

namespace TasteTrailApp.Infrastructure.Common.Data;
public class TasteTrailDbContext : DbContext //: IdentityDbContext<User, IdentityRole, string>
{
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Venue> Venues { get; set; }
    public DbSet<MenuItemModel> MenuItems { get; set; }
    public DbSet<VenuePhotos> VenuePhotos { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }

    public TasteTrailDbContext(DbContextOptions<TasteTrailDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
        modelBuilder.ApplyConfiguration(new MenuConfiguration());
        modelBuilder.ApplyConfiguration(new MenuItemConfiguration());
        modelBuilder.ApplyConfiguration(new VenueConfiguration());
        modelBuilder.ApplyConfiguration(new VenuePhotosConfiguration());
    }

}
