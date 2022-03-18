using Data.Context;
using imdbAPI.Extensions;
using Microsoft.EntityFrameworkCore;
using Service.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<imdbContext>(options => options.UseSqlServer("Server=PROTECH-DESK02\\SQLEXPRESS; Database=ApiVictorIMDB; Trusted_Connection=yes;"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ActorProfile).Assembly);

builder.Services.AddDependenceInjection()
    .AddAuthenticationConfig(builder.Configuration)
    .AddCustomSwaggerGen(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
