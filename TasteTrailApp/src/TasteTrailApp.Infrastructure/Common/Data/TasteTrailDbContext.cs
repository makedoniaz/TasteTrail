using Microsoft.EntityFrameworkCore;
using TasteTrailApp.Infrastructure.Common.Data.Configurations;

// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using TasteTrailApp.Core.Venues.Models;
using TasteTrailApp.Core.VenuesPhotos.Models;
using TasteTrailApp.Core.Feedbacks.Models;
using TasteTrailApp.Core.Menus.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TasteTrailApp.Core.MenuItems.Models;
using TasteTrailApp.Core.Users.Models;

namespace TasteTrailApp.Infrastructure.Common.Data;
public class TasteTrailDbContext : IdentityDbContext<User, IdentityRole, string>
{
    public DbSet<Menu> Menus { get; set; }

    public DbSet<Venue> Venues { get; set; }

    public DbSet<MenuItem> MenuItems { get; set; }

    public DbSet<VenuePhotos> VenuePhotos { get; set; }

    public DbSet<Feedback> Feedbacks { get; set; }

    public TasteTrailDbContext(DbContextOptions options) : base(options)
    {}
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
