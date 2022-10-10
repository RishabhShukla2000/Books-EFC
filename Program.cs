global using BookWriters.Context;
global using Microsoft.EntityFrameworkCore;
using BookWriters.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BWContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BWConnection"));
});
builder.Services.AddScoped<IBookServices, BookServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
