using Company_CRM.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
string connectionStrings;
if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
    connectionStrings = builder.Configuration.GetConnectionString("LaptopConnectionString");
else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    connectionStrings = builder.Configuration.GetConnectionString("WindowsConntectionString");
else
    connectionStrings = builder.Configuration.GetConnectionString("MacConntectionString");
builder.Services.AddDbContext<SneakerFactoryContext>(options => options.UseNpgsql(connectionStrings));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Verification/Auth";
        options.LogoutPath = "/Verification/Logout";
    });


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.MapControllerRoute(
    name: "registration",
    pattern: "{controller=Verification}/{action=Index}");

app.Run();