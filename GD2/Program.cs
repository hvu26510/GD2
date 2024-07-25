using Microsoft.EntityFrameworkCore;
using GD2.Data;
using GD2.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();//* them
builder.Services.AddSession();//*them

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<AuthenticationService>();//*them
builder.Services.AddHttpContextAccessor();//*them

builder.Services.AddDbContext<GD2DbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.UseSession();//*

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
