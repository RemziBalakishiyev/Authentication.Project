using AppJwtEmployee.DBL.AutoMapper;
using AppJwtEmployee.DBL.DAL.Abstract;
using AppJwtEmployee.DBL.DAL.Persistance.Context;
using AppJwtEmployee.DBL.DAL.Persistance.Repositories;
using AppJwtEmployee.DBL.DAL.Persistance.Repositories.EmployeeRepsitory;
using AppJwtEmployee.DBL.Services.Abstract;
using AppJwtEmployee.DBL.Services.Concrete;
using AppJwtEmployee.DBL.Utility.Result.Abstract;
using AppJwtEmployee.DBL.Utility.Result.Concrete;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(new Assembly[] { typeof(MapperConfig).GetTypeInfo().Assembly });

builder.Services.AddDbContext<EmpContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IResultFactory<>), typeof(ResultFactory<>));
builder.Services.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,>));
builder.Services.AddScoped(typeof(IQueryRepository<,>), typeof(QueryRepository<,>));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(builder =>
{
    builder
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowAnyOrigin();
});

app.UseAuthorization();
    
app.MapControllers();

app.Run();
