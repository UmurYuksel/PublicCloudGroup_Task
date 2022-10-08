using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using publiccloudgroup_api.Data;
using publiccloudgroup_api.Interfaces;
using publiccloudgroup_api.Profiles;
using publiccloudgroup_api.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//For DI.
builder.Services.AddScoped<IVmOperations, VmOperationsService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IToken, TokenService>();

//For Auto Mapping
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

//For Login & Authorization
builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlite("Data Source = ./Data/UserDb.db"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
    };
});
builder.Services.AddAuthorization();

//To be able to consume the API from my react client.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CQRSPolicy", builder => 
    {
        builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Setting the secrets =>
System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "./Constants/secret.json");

app.UseCors("CQRSPolicy");
app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication(); 
app.UseAuthorization();
app.MapControllers();
app.Run();
