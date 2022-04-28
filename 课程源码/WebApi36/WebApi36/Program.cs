using System.Diagnostics;
using WebApi36;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/weatherforecast", () =>
{
    return "Hello world";
});
app.UseStopWatch();

//app.UseMiddleware<StopwatchMiddleware>();

//app.Use(async (context, next) =>
//{
//    var stopWatch = new Stopwatch();
//    stopWatch.Start();

//    await next();

//    stopWatch.Stop();
//    Console.WriteLine(stopWatch.ElapsedTicks);
//});

app.Run();
