using businessProject.Business.Implementation;
using businessProject.Business.Interface;
using businessProject.Models;
using businessProject.Repository.Implementation;
using businessProject.Repository.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Create the conection with SQL Server
builder.Services.AddDbContext<BusinessProjectContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings: businessProject"]));

//create intance for DI
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ITypeOfTransportRepository, TypeOfTransportRepository>();
builder.Services.AddTransient<ITypeOfTransportBL, TypeOfTransportBL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
