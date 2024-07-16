using Microsoft.EntityFrameworkCore;
using TasteTrailApp.Infrastructure.Common.Data.Configuration;

// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using FeedbackModel = TasteTrailApp.Core.Feedback.Models.Feedback;
using MenuModel = TasteTrailApp.Core.Menu.Models.Menu;
using MenuItemModel = TasteTrailApp.Core.MenuItem.Models.MenuItem;
using VenueModel = TasteTrailApp.Core.Venue.Models.Venue;
using VenuePhotosModel = TasteTrailApp.Core.VenuePhotos.Models.VenuePhotos;

namespace TasteTrailApp.Infrastructure.Common.Data;
public class TasteTrailDbContext : DbContext //: IdentityDbContext<User, IdentityRole, string>
{
    public DbSet<MenuModel> Menus { get; set; }
    public DbSet<VenueModel> Venues { get; set; }
    public DbSet<MenuItemModel> MenuItems { get; set; }
    public DbSet<VenuePhotosModel> VenuePhotos { get; set; }
    public DbSet<FeedbackModel> Feedbacks { get; set; }

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
