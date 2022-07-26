using LibraryToDocs.Configurations;
using LibraryToDocs.Data;
using LibraryToDocs.Service.FileDataService;
using LibraryToDocs.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MediatR;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo
{
    Version = "v1",
    Title = "DeliveryToDocs :: API",
    Description = "Gestão, Controle e Idenxação de Documentos",
    TermsOfService = new Uri("https://example.com/terms"),
    Contact = new OpenApiContact
    {
        Name = "Eduardo Barros",
        Email = "barrosebs@gmail.com",
        Url = new Uri("https://twitter.com/spboyer"),
    },
    License = new OpenApiLicense
    {
        Name = "EBDeveloper",
        Url = new Uri("https://example.com/license"),
    }
}));


//-- AutoMapper -->
//builder.Services.AddAutoMapper(typeof(Service.ClassMapper));

// database..
var databaseService = CoreSettings.GetService(CoreSettings.Core);
switch (databaseService.Repository.Provider)
{
    case "SqlServer":
        builder.Services.AddDbContext<CoreDbContext>(options =>
            options.UseSqlServer(databaseService.Repository.ConnectionString));
        break;
    case "MySql":
        builder.Services.AddDbContext<CoreDbContext>(options =>
            options.UseMySql(databaseService.Repository.ConnectionString,
                new MySqlServerVersion(new Version(8, 0, 21)))); // Replace with your server version and type.
        break;
    default:
        throw new Exception("DatabaseType not configured");
}
// filedata
var appSettings = CoreSettings.GetSettings();
switch (appSettings.FileDataSettings.FileDataStorage)
{
    case EFileDataStorage.AWS:
        builder.Services.AddScoped<IStorageService, AWSStorage>();
        break;
    case EFileDataStorage.Azure:
        builder.Services.AddScoped<IStorageService, AzureStorage>();
        break;
    case EFileDataStorage.CGP:
        builder.Services.AddScoped<IStorageService, GoogleCloudStorage>();
        break;
    default:
        builder.Services.AddScoped<IStorageService, LocalStorage>();
        break;
}

builder.Services.AddIdentityConfiguration();

var assembly = AppDomain.CurrentDomain.Load("LibraryToDoc.Service");
builder.Services.AddMediatR(assembly);

// configure jwt authentication
var key = System.Text.Encoding.UTF8.GetBytes(appSettings.Jwt.Key);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthConfiguration();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();
