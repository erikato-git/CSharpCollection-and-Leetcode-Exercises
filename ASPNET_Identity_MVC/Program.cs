using ASPNET_Identity_MVC.Controllers;
using ASPNET_Identity_MVC.Data;
using ASPNET_Identity_MVC.Interfaces;
using ASPNET_Identity_MVC.Models;
using ASPNET_Identity_MVC.Services;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(e => e.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();     // Identity: Enables Two-factor-authentication and cookies
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IEmailSender, SendGmail>();
builder.Services.AddAuthentication()
.AddFacebook(facebookOptions =>
{
    facebookOptions.AppId = builder.Configuration["Authentication:Facebook:AppId"];
    facebookOptions.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
})
.AddGoogle(opt =>
{
    opt.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    opt.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});


// ILogger
var serviceProvider = builder.Services.BuildServiceProvider();
var logger = serviceProvider.GetService<ILogger<AppUsers>>();
builder.Services.AddSingleton(typeof(ILogger), logger);



builder.Services.Configure<IdentityOptions>(opt =>
{
    //opt.Password.RequiredLength = 5;
    //opt.Password.RequireLowercase = true;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    opt.Lockout.MaxFailedAccessAttempts = 2;
    //opt.SignIn.RequireConfirmedAccount = true;
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
