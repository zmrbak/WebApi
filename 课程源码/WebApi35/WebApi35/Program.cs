using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/weatherforecast", () =>
{
    Console.WriteLine("MapGet");
    return "Hello World"; 
});


app.Use(async (context, next) =>
{
    var stopWatch = new Stopwatch();
    stopWatch.Start();
    
    await next();

    stopWatch.Stop();
    Console.WriteLine(stopWatch.ElapsedTicks);
});


//.Use(async (context, next) =>
//{
//    Console.WriteLine("use 2 start");
//    await next();
//    Console.WriteLine("use 2 end");
//})
//.Use(async (context, next) =>
//{
//    Console.WriteLine("use 3 start");
//    await next();
//    Console.WriteLine("use 3 end");
//});


app.Run();