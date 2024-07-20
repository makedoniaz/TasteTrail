using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

using TasteTrailApp.Core.Menus.Repositories;
using TasteTrailApp.Core.Menus.Services;

using TasteTrailApp.Core.MenuItems.Repositories;
using TasteTrailApp.Core.MenuItems.Services;

using TasteTrailApp.Core.Venues.Repositories;
using TasteTrailApp.Core.Venues.Services;

using TasteTrailApp.Core.VenuesPhotos.Repositories;
using TasteTrailApp.Core.VenuesPhotos.Services;
using TasteTrailApp.Infrastructure.Common.Data;

using TasteTrailApp.Infrastructure.Menus.Repositories;
using TasteTrailApp.Infrastructure.Menus.Services;

using TasteTrailApp.Infrastructure.MenuItems.Repositories;
using TasteTrailApp.Infrastructure.MenuItems.Services;

using TasteTrailApp.Infrastructure.Venues.Repositories;
using TasteTrailApp.Infrastructure.Venues.Services;

using TasteTrailApp.Infrastructure.VenuesPhotos.Repositories;
using TasteTrailApp.Infrastructure.VenuesPhotos.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//One more
builder.Services.AddSwaggerGen();

#region [ DI DbContext ]

builder.Services.AddDbContext<TasteTrailDbContext>(
    (optionsBuilder) => optionsBuilder.UseNpgsql(
        connectionString: builder.Configuration.GetConnectionString("SqlConnection")
    )
);
#endregion

#region [ DI Asp Identity ]

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {
    //options.Password.RequireDigit = true;
}).AddEntityFrameworkStores<TasteTrailDbContext>();
#endregion

#region [ DI Repositories ]

// builder.Services.AddSingleton<TasteTrailDbContext>();

builder.Services.AddTransient<IMenuItemRepository, MenuItemEFCoreRepository>();
builder.Services.AddTransient<IVenuePhotosRepository, VenuePhotosEFCoreRepository>();
builder.Services.AddTransient<IVenueRepository, VenueEFCoreRepository>();
builder.Services.AddTransient<IMenuRepository, MenuEFCoreRepository>();

#endregion

#region [ DI Services ]

builder.Services.AddTransient<IVenueService, VenueService>();
builder.Services.AddTransient<IMenuItemService, MenuItemService>();
builder.Services.AddTransient<IMenuService, MenuSerivce>();
builder.Services.AddTransient<IVenuePhotosService, VenuePhotosService>();

#endregion

#region [ Fluent Validation ]

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

#endregion

var app = builder.Build();
    
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else //FIX this
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
