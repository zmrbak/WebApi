var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet(pattern: "/weatherforecast", () =>
{
    return "/WEATHERFORECAST";
});

app.Map( pattern: "/app1", () =>
{
    return "/APP1";
});

app.Map(pathMatch: "/app2",
    app2 =>
    {
        app2.Run(
            async hander =>
            {
                await hander.Response.WriteAsync("/APP2");
            }
        );
    }
);

app.Run();
