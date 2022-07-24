using Microsoft.AspNetCore.Mvc;
using WebApi016.Attibutes;
using WebApi016.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddMvc(SetUpAction);
//void SetUpAction(MvcOptions options)
//{
//    options.Filters.Add<MyFilter>();
//}

//builder.Services.AddMvc(options => { options.Filters.Add<MyFilter>(); });
//builder.Services.AddScoped<MyActionFilterAttribute>();

builder.Services.AddControllers();
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
