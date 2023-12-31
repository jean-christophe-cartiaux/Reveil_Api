
using System.Data.SqlClient;

string angular = "angular";
var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//! cr�ation de la Sql connection et nommage de la connection string 
builder.Services.AddTransient(sp => new SqlConnection(configuration.GetConnectionString("default")));
builder.Services.AddCors(o => o.AddPolicy(angular, options =>
    options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//! app.Use().UseMiddleware();
app.UseCors(angular);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
