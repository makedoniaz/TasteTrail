using System.Reflection;
using FluentValidation;
using TasteTrailApp.Core.Feedback.Repositories;
using TasteTrailApp.Core.Feedback.Services;
using TasteTrailApp.Core.Menu.Repositories;
using TasteTrailApp.Core.Menu.Services;

using TasteTrailApp.Core.MenuItem.Repositories;
using TasteTrailApp.Core.MenuItem.Services;

using TasteTrailApp.Core.Venue.Repositories;
using TasteTrailApp.Core.Venue.Services;

using TasteTrailApp.Core.VenuePhotos.Repositories;
using TasteTrailApp.Core.VenuePhotos.Services;

using TasteTrailApp.Infrastructure.Context;
using TasteTrailApp.Infrastructure.Feedback.Repositories;
using TasteTrailApp.Infrastructure.Feedback.Services;
using TasteTrailApp.Infrastructure.Menu.Repositories;
using TasteTrailApp.Infrastructure.Menu.Services;

using TasteTrailApp.Infrastructure.MenuItem.Repositories;
using TasteTrailApp.Infrastructure.MenuItem.Services;

using TasteTrailApp.Infrastructure.Venue.Repositories;
using TasteTrailApp.Infrastructure.Venue.Services;

using TasteTrailApp.Infrastructure.VenuePhotos.Repositories;
using TasteTrailApp.Infrastructure.VenuePhotos.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//One more
builder.Services.AddSwaggerGen();

#region [ DI Repositories ]

builder.Services.AddSingleton<DapperContext>();

builder.Services.AddTransient<IMenuItemRepository, MenuItemDapperRepository>();
builder.Services.AddTransient<IVenuePhotosRepository, VenuePhotosDapperRepository>();

builder.Services.AddTransient<IVenueRepository, VenueDapperRepository>();
builder.Services.AddTransient<IMenuRepository, MenuDapperRepository>();

builder.Services.AddTransient<IFeedbackRepository, FeedbackDapperRepository>();
builder.Services.AddTransient<IFeedbackService, FeedbackService>();

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
