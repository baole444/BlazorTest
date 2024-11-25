using DBConnectLibrary;
using Microsoft.EntityFrameworkCore;
using StaffServices;
using StaffServices.Models;
using StaffServices.Respository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Interface and injection, using singleton to allow a single instance during runtime
// Fallback to if ECF failed
builder.Services.AddSingleton<IMySQLQuery, MySQLQuery>();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmployeeRespository, EmployeeRespository>();

builder.Services.AddScoped<IDepartmentRespository, DepartmentRespository>();

builder.Services.AddDbContext<StaffContex>(opts => opts.UseMySQL(ConfigLoader.GetConfiguration().GetConnectionString("default")));

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
