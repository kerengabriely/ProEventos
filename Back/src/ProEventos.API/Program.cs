using Microsoft.EntityFrameworkCore;
using ProEventos.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string mysqlConnection = builder.Configuration.GetConnectionString("mysqlConnection");

builder.Services.AddDbContext<DataContext>(options => options.UseMySql(mysqlConnection, ServerVersion.AutoDetect(mysqlConnection)));

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
}  else {
    app.UseHttpsRedirection();
}

app.UseCors(x => x.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
