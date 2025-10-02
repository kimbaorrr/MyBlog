using AspNetCore.Identity.Mongo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MyBlog.DB;
using MyBlog.DB.Entities;
using MyBlog.Repositories;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services;
using MyBlog.Services.Interfaces;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services
    .AddControllersWithViews()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();

builder.Services.AddHttpClient();

// DB Context
builder.Services.AddScoped<MyBlogContext>();

// Identity Auth
builder.Services.AddIdentityMongoDbProvider<ApplicationUser, ApplicationRole>(
identityOptions =>
{
    
},
mongoOptions =>
{
    mongoOptions.ConnectionString = builder.Configuration["Database:MongoDB:Url"] ?? string.Empty;
    mongoOptions.MigrationCollection = "auths";
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/admin/auth/login";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

});

// Repositories
builder.Services.AddScoped<IIntroductionRepository, IntroductionRepository>();
builder.Services.AddScoped<IPersonalRepository, PersonalRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<IToolRepository, ToolRepository>();

// Services
builder.Services.AddScoped<ICVService, CVService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IToolService, ToolService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<ICaptchaService, CaptchaService>();
builder.Services.AddScoped<IAccountService, AccountService>();

var app = builder.Build();




// Multi Languages
CultureInfo viCulture = new CultureInfo("vi");
viCulture.DateTimeFormat.ShortTimePattern = "HH:mm";
viCulture.DateTimeFormat.LongTimePattern = "HH:mm:ss";

CultureInfo enCulture = new CultureInfo("en");
enCulture.DateTimeFormat.ShortTimePattern = "HH:mm";
enCulture.DateTimeFormat.LongTimePattern = "HH:mm:ss";

var supportedCultures = new[] { enCulture, viCulture };

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("vi")
    .AddSupportedCultures(supportedCultures.Select(c => c.Name).ToArray())
    .AddSupportedUICultures(supportedCultures.Select(c => c.Name).ToArray());

app.UseRequestLocalization(localizationOptions);


// For testing only
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    using var scope = app.Services.CreateScope();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

    var adminEmail = "admin@example.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);

    if (adminUser == null)
    {
        adminUser = new ApplicationUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(adminUser, "1234");
        if (result.Succeeded)
        {
            await userManager.ResetAuthenticatorKeyAsync(adminUser);
            var key = await userManager.GetAuthenticatorKeyAsync(adminUser);

            logger.LogInformation("======================================");
            logger.LogInformation("Admin account: {Email}", adminEmail);
            logger.LogInformation("Admin password: 1234");
            logger.LogInformation("Admin 2FA key: {Key}", key);
            logger.LogInformation("======================================");
        }
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapAreaControllerRoute(
    areaName: "Admin",
    name: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await app.RunAsync();
