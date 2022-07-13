using BackEnd.Entities;
using BackEnd.Utilities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SISTEMA_ACADEMICOContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
string connString = builder.Configuration.GetConnectionString("DefaultConnection");
Util.ConnectionString = connString;

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

app.UseAuthorization();

app.MapControllers();

app.Run();
