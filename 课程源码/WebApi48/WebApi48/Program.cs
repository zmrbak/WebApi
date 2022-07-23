var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(new DeveloperExceptionPageOptions { SourceCodeLineCount = 3 });
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    //app.UseExceptionHandler("/api/Values");
    //app.UseExceptionHandler(options =>
    //{
    //    options.Run(async context =>
    //    {
    //        context.Response.ContentType = "text/html";
    //        context.Response.StatusCode = 200;
    //        await context.Response.WriteAsync("error......");
    //    });
    //});
    app.UseExceptionHandler(new ExceptionHandlerOptions
    {
        AllowStatusCode404Response = true,
        //ExceptionHandler = async context =>
        //    {
        //        context.Response.ContentType = "text/html";
        //        context.Response.StatusCode = 200;
        //        await context.Response.WriteAsync("error......");
        //    },
        ExceptionHandlingPath = "/api/Values"
    });
}



app.UseAuthorization();

app.MapControllers();

app.Run();
