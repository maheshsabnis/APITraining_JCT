// 1. WebAppliationBuilder clas
// Hosting COnfiguration
// Kestral Hosting COnfigurations
using Core_API.CustomMiddlewares;
using Core_API.Models;
using Core_API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// REgiter the CompanyCOntext aka DbCOntext in DI COntainer

builder.Services.AddDbContext<CompanyContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnStr"));
});


builder.Services.AddDbContext<JCISecurityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SecureConnStr"));
});

// REgister UserManager<IdentityUser>, RoleManager<IdentityRole>, and SignInManager<IdetityUser>
// In DI COntainer
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<JCISecurityDbContext>();


// Register the DepartmentService and EmployeeService in DI COntaienr

builder.Services.AddScoped<IService<Department,int>, DepartmentService>();
builder.Services.AddScoped<IService<Employee, int>, EmployeeService>();

// register the AuthenticationSerice

builder.Services.AddScoped<AuthenticationService>();

// Add services to the container aka DI Container.

builder.Services.AddControllers()
    .AddJsonOptions(options => 
    {
        // SUpress the default JSOn Serializer i.e. Camel-Casing
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
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

app.UseAuthentication(); // FOr Use BAsed Login
app.UseAuthorization();

// APply the Custom Exception MIddleware
app.UseAppException();


app.MapControllers();

app.Run();
