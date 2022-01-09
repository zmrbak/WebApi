using WebApi23.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddXmlFile("xml.xml");
builder.Configuration.AddJsonFile("json.json");
builder.Configuration.AddIniFile("ini.ini");

var b1 = new List<KeyValuePair<string, string>>();
b1.Add(new KeyValuePair<string, string>("MyKey", "My Key From AddInMemoryCollection"));
builder.Configuration.AddInMemoryCollection(b1);

builder.Configuration.AddFromSQL("数据库链接", "数据库查询语句");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var a1 = app.Configuration["MyKey"];

var a2 = new Logging1();
app.Configuration.GetSection("Logging1").Bind(a2);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();




public class Logging1
{
    public Loglevel LogLevel { get; set; }
}

public class Loglevel
{
    public string Default { get; set; }
    public string MicrosoftAspNetCore { get; set; }
}


