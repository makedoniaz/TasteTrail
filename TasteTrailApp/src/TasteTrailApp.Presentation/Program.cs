using System.Reflection;
using FluentValidation;
using TasteTrailApp.Core.Repositories;
using TasteTrailApp.Core.Services.Base;
using TasteTrailApp.Infrastructure.Context;
using TasteTrailApp.Infrastructure.Repositories;
using TasteTrailApp.Infrastructure.Services;

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
