using LUMAApp.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;


// For Entity Framework
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("connMSSQL")));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name:"CORS",
                      builder =>
                      {
                          builder.AllowAnyHeader()
                          .WithOrigins("http://localhost:3000")
                          .AllowCredentials()
                          .AllowAnyMethod();
                      });
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

app.UseCors("CORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
