using MyBlog.Repositories;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services;
using MyBlog.Services.Interfaces;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using MyBlog.DB;

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

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(
    areaName: "Admin",
    name: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
