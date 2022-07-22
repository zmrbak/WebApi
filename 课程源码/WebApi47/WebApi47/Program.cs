using Microsoft.AspNetCore.Mvc.Formatters;
using System.Xml;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.WriteIndented = true;
    })
    //.AddXmlOptions(options => { 
    //    options.
    //})
    .AddMvcOptions(options => {
        options.OutputFormatters.Add(new XmlSerializerOutputFormatter(new XmlWriterSettings
        {
            Indent = true,
            IndentChars="\t",
        }));
    })
    //.AddXmlSerializerFormatters()
    ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
