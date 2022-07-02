using CanvasAssignmentSync.Services;
using CanvasAssignmentSync.Data;
using CanvasAssignmentSync.Models;
using CanvasAssignmentSync.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);


var services = builder.Services;
var configuration = builder.Configuration;




builder.Services.AddDbContext<CourseDbContext>(options =>
{
    options.UseSqlite("Data source = Courses.db");
    options.EnableSensitiveDataLogging();
});
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<CourseDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;

})
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";

    })
    .AddGoogle(googleOptions =>
    {
        googleOptions.CallbackPath = "/signin-google";
        googleOptions.SignInScheme = IdentityConstants.ExternalScheme;
        googleOptions.SaveTokens = true;
        googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
        googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
    });

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);
builder.Services.AddScoped<ICanvasRepository, CanvasRepository>();
builder.Services.AddScoped<ICanvasService, CanvasService>();
builder.Services.AddScoped<IMsToDoRepository, MsToDoRepository>();
builder.Services.AddScoped<IMsToDoService, MsToDoService>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjQxMjM5QDMyMzAyZTMxMmUzMEwwL0wrV3lCM1BpcmVnN05aWGJuWjRycmZvM3ZYbXF0WEk5S25INzU0SE09");
builder.Services.AddSyncfusionBlazor(options => {});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
