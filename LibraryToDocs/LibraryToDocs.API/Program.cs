using Microsoft.OpenApi.Models;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
