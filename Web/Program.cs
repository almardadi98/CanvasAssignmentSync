using System.Text.Json.Serialization;
using Domain.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Persistence;
using Persistence.Repositories;
using Services;
using Services.Abstractions;
using Web.Authorization;

var builder = WebApplication.CreateBuilder(args);


var services = builder.Services;
var configuration = builder.Configuration;

var connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<RepositoryDbContext>(options =>
    options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Web")));



builder.Services.AddDefaultIdentity<IdentityUser>(options =>
        options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<RepositoryDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;

})
    .AddCookie(options =>
    {
        options.LoginPath = "/Identity/Account/Login";
        options.LogoutPath = "/Identity/Account/Logout";

    })
    .AddGoogle(googleOptions =>
    {
        googleOptions.CallbackPath = "/signin-google";
        googleOptions.SignInScheme = IdentityConstants.ExternalScheme;
        googleOptions.SaveTokens = true;
        googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
        googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
    })
    .AddMicrosoftAccount(microsoftOptions =>
    {
        microsoftOptions.ClientId = configuration["Authentication:Microsoft:ClientId"];
        microsoftOptions.ClientSecret = configuration["Authentication:Microsoft:ClientSecret"];
    })
    ;



builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.AddScoped<IAuthorizationHandler, CanvasOptionsIsOwnerAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, CanvasOptionsAdministratorsAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, CanvasOptionsManagerAuthorizationHandler>();


builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();


builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjQxMjM5QDMyMzAyZTMxMmUzMEwwL0wrV3lCM1BpcmVnN05aWGJuWjRycmZvM3ZYbXF0WEk5S25INzU0SE09");
builder.Services.AddSyncfusionBlazor(options => {});

var app = builder.Build();


// Run migrations on startup
using (var scope = app.Services.CreateScope())
{
    var dbServices = scope.ServiceProvider;

    var context = dbServices.GetRequiredService<RepositoryDbContext>();
    context.Database.Migrate();
}


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
