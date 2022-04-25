using WebApi33;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddSingleton<IHostedService, MyHostedService>();
builder.Services.AddHostedService<MyBackgroundService>();

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

//var host = Host.CreateDefaultBuilder()
//    .ConfigureServices(services =>
//    {
//        //services.AddHostedService<MyBackgroundService>();
//        services.AddSingleton<IHostedService, MyHostedService>();
//    })
//    .Build();
//host.Run();
////await host.RunAsync();
