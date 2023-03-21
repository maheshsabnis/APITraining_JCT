// 1. WebAppliationBuilder clas
// Hosting COnfiguration
// Kestral Hosting COnfigurations
using Core_API.Models;
using Core_API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// REgiter the CompanyCOntext aka DbCOntext in DI COntainer

builder.Services.AddDbContext<CompanyContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnStr"));
});


// Register the DepartmentService and EmployeeService in DI COntaienr

builder.Services.AddScoped<IService<Department,int>, DepartmentService>();


// Add services to the container aka DI Container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline. AKA Middlewares aka HTTP Request Processig
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
