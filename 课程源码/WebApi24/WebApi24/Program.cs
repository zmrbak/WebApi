using WebApi24.Logs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var a1 = builder.Logging.Services.ToList();
builder.Logging.ClearProviders();
//var a2 = builder.Logging.Services.ToList();
//var a3=a1.Except(a2).ToList();
//builder.Logging.AddConsole();
//builder.Logging.AddDebug();
//builder.Logging.AddEventLog();
//builder.Logging.AddEventSourceLogger();
builder.Logging.AddSqlLog("Êý¾Ý¿âÁ´½Ó");


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
