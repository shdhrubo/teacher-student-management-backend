





using CRUD.API.Data;
using CRUD.API.Models.Domains;
using CRUD.API.Models.DTOs;
using CRUD.API.Repositories;
using CRUD.API.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using MediatR;
using CRUD.API.Validators;
using CRUD.API.Handler.StudentHandler;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Autofac.Core;
using Auth0.AspNetCore.Authentication;
using System.Security.Claims;
using CRUD.API;
using Microsoft.AspNetCore.Authorization;
using CRUD.API.Models.MongoModels;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

// MongoDB configuration
var mongoDbSettings = builder.Configuration.GetSection("TeacherStudentDatabase").Get<OfficeStaffDatabaseSettings>();
var client = new MongoClient(mongoDbSettings.ConnectionString);
var database = client.GetDatabase(mongoDbSettings.DatabaseName);

// Register IMongoGenericRepository<Book> service
builder.Services.AddSingleton(database);
builder.Services.AddScoped(typeof(IMongoGenericRepository<>), typeof(MongoGenericRepository<>));
builder.Services.AddScoped<IMongoGenericRepository<OfficeStaff>>(provider =>
    new MongoGenericRepository<OfficeStaff>(provider.GetRequiredService<IMongoDatabase>(), mongoDbSettings.TeacherStudentCollectionName));
builder.Services.AddScoped<IOfficeStaffService, OfficeStaffService>();

//meidatR
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
// Register repositories and services
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

// Register FluentValidation
builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
      fv.RegisterValidatorsFromAssemblyContaining<CreateTeacherCommandValidator>();
      fv.RegisterValidatorsFromAssemblyContaining<CreateStudentCommandValidator>();
    });

// CORS configuration
builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(builder =>
  {
    builder.WithOrigins("http://localhost:4200")
           .AllowAnyHeader()
           .AllowAnyMethod();
  });
});





var domain = $"https://{builder.Configuration["Auth0:Domain"]}/";
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
  options.Authority = domain;
  options.Audience = builder.Configuration["Auth0:Audience"];
  options.TokenValidationParameters = new TokenValidationParameters
  {
    NameClaimType = ClaimTypes.NameIdentifier
  };
});
//scope handler
//builder.Services.AddAuthorization(options =>
//{
//  options.AddPolicy("read:messages", policy => policy.Requirements.Add(new
//  HasScopeRequirement("read:messages", domain)));
//});

builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

// Custom exception handling middleware
app.UseMiddleware<ExceptionMiddleware>();

// Add authorization and CORS middleware
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();


