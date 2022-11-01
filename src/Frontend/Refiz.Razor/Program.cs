using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Refiz.Application.Infrastructure;
using Refiz.Application.Infrastructure.Extensions;
using Refiz.Razor.Configuration;
using Refiz.Razor.Infrastructure;
using Refiz.Razor.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .ConfigureCustomConfiguration()
    .Build();
builder.Configuration.AddConfiguration(configuration);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
        opt =>
        {
            opt.LoginPath = "/Account/Login";
            opt.LoginPath = "/Account/Logout";
        });
builder.Services.Configure<UserManagerOption>(builder.Configuration.GetSection("UserManager"));
builder.Services.AddHealthChecks()
    .AddSqlServer(configuration.GetConnectionString("Refiz"), timeout: TimeSpan.FromSeconds(3));
builder.Services.AddCustomApplicationServices(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapHealthChecks("/health", new HealthCheckOptions()
{
    AllowCachingResponses = false
});

app.UseStaticFiles();
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();