using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.WebEncoders;
using VehicleRoutesBuildingWebApplication.Data;
using VehicleRoutesBuildingWebApplication.Models.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc();

builder.Services.Configure<WebEncoderOptions>(options => 
{
    options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
});

// Добавил собственный DbContext
builder.Services.AddDbContext<Context>(options 
    => options.UseNpgsql(builder.Configuration.
        GetConnectionString("DemoConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();