using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Refiz.Application.Infrastructure;
using Refiz.Blazor.Data;
using Refiz.Blazor.Extensions;
using Refiz.Infrastructure;
using Refiz.Queries;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .ConfigureCustomConfiguration()
    .Build();

builder.Configuration.AddConfiguration(configuration);

var connectionString = configuration.GetConnectionString("Refiz");

// Add services to the container.

var serverVesrion = new MariaDbServerVersion(new Version(10, 9, 5));
builder.Services.AddDbContext<RefizContext>(opt => 
    opt.UseMySql(connectionString, serverVesrion)
        .EnableDetailedErrors()
);

builder.Services.AddScoped<IRefizContext, RefizContext>();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<RefizContext>();

builder.Services.AddTransient<ICipher>(_ => new Cipher("salt"));
builder.Services.AddMediatR(typeof(Cipher));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Scan(scan =>
    scan.FromAssemblyOf<IBaseQuery>()
        .AddClasses()
        .AsMatchingInterface()
        .WithTransientLifetime()
    );

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

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