using Forum1.Models.DBContext;
using Forum1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ForumContext>(options =>
    options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Authorization/Login");
        options.LogoutPath = new PathString("/Authorization/Login");
        options.AccessDeniedPath = "/Home/Index";
    });

builder.Services.AddAuthorization();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "authorization",
    pattern: "{controller=Authorization}/{action=Login}/{id?}");
app.Run();