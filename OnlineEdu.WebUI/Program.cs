using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.Mappings;
using OnlineEdu.WebUI.Services;
using OnlineEdu.WebUI.Services.RoleServices;
using OnlineEdu.WebUI.Validators;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<OnlineEduContext>()
    .AddErrorDescriber<CustomErrorDescriber>();
builder.Services.AddAutoMapper(typeof(GeneralMapping));
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(
    JwtBearerDefaults.AuthenticationScheme, opt =>
    {
        opt.LoginPath = "/Login/SignIn";
        opt.LogoutPath = "/Login/Logout";
        opt.AccessDeniedPath = "/ErrorPage/AccessDenied";
        opt.Cookie.SameSite=SameSiteMode.Strict;
        opt.Cookie.HttpOnly = true;
        opt.Cookie.SecurePolicy=CookieSecurePolicy.SameAsRequest;
        opt.Cookie.Name = "OnlineEduJwt";
    });

builder.Services.ConfigureApplicationCookie(cfg =>
{
    cfg.LoginPath = "/Login/SignIn";
    cfg.LogoutPath = "/Login/Logout";
    cfg.AccessDeniedPath = "/ErrorPage/AccessDenied";   

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseStatusCodePagesWithReExecute("/ErrorPage/NotFound404/"); // Hata sayfalarý middleware'i

app.UseAuthentication(); // Kimlik doðrulama middleware'i
app.UseAuthorization();  // Yetkilendirme middleware'i

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
