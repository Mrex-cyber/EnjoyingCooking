using EnjoyingCookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using EnjoyingCookingAPI.AuthO;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddDbContext<CookingContext>(opt => opt.UseSqlite());
builder.Services.AddDbContext<UsersCashContext>(opt => opt.UseSqlite());

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = AuthOptions.ISSUER,
        ValidAudience = AuthOptions.AUDIENCE,
        IssuerSigningKey = AuthOptions.GetSecurityKey(),
    };
});
builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
app.UseCors(e =>
e.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
);

app.MapControllers();

app.Run();
