using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Forbidden/";
    });


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

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/login", async context =>
{
    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "20995658@qq.com"),
                    new Claim("FullName", "ÕÔÇìÃ÷"),
                    new Claim(ClaimTypes.Role, "Administrator"),
                };

    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

    var authProperties = new AuthenticationProperties
    {
        //AllowRefresh = <bool>,
        // Refreshing the authentication session should be allowed.

        //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
        // The time at which the authentication ticket expires. A 
        // value set here overrides the ExpireTimeSpan option of 
        // CookieAuthenticationOptions set with AddCookie.

        //IsPersistent = true,
        // Whether the authentication session is persisted across 
        // multiple requests. When used with cookies, controls
        // whether the cookie's lifetime is absolute (matching the
        // lifetime of the authentication ticket) or session-based.

        //IssuedUtc = <DateTimeOffset>,
        // The time at which the authentication ticket was issued.

        //RedirectUri = <string>
        // The full path or absolute URI to be used as an http 
        // redirect response value.
    };

    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        await context.Response.WriteAsync("Login OK");
});
app.MapGet("/logout", async context =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    await context.Response.WriteAsync("Logout OK");
});

app.Run();
