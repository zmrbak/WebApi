var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var aa = app.Configuration["MyKey"];
Console.WriteLine(aa);

var a1 = app.Configuration.GetChildren();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //Console.WriteLine("app.Environment.IsDevelopment()");
}

app.UseAuthorization();

app.MapControllers();

app.Run();
