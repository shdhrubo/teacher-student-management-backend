//using CRUD.API.Data;
//using CRUD.API.Models.Domains;
//using CRUD.API.Models.DTOs;
//using CRUD.API.Repositories;
//using CRUD.API.Services;
//using FluentValidation;
//using FluentValidation.AspNetCore;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using System.Reflection;
//using MediatR;
//using CRUD.API.Validators;
//using CRUD.API.Handler.StudentHandler;
//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//// Add database context
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

////meidatR
////builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
//// Register repositories and services
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped<IStudentService, StudentService>();
//builder.Services.AddScoped<ITeacherService, TeacherService>();

//// Register FluentValidation
//builder.Services.AddControllers()
//    .AddFluentValidation(fv =>
//    {
//      fv.RegisterValidatorsFromAssemblyContaining<CreateTeacherCommandValidator>();
//      fv.RegisterValidatorsFromAssemblyContaining<CreateStudentCommandValidator>();
//    });


//// CORS configuration
//builder.Services.AddCors(options =>
//{
//  options.AddDefaultPolicy(builder =>
//  {
//    builder.WithOrigins("http://localhost:4200")
//           .AllowAnyHeader()
//           .AllowAnyMethod();
//  });
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//  app.UseSwagger();
//  app.UseSwaggerUI();
//}

//// Custom exception handling middleware
//app.UseMiddleware<ExceptionMiddleware>();

//app.UseAuthorization();
//app.UseCors();

//app.MapControllers();

//app.Run();





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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

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




//using CRUD.API.Data;
//using CRUD.API.Models.Domains;
//using CRUD.API.Models.DTOs;
//using CRUD.API.Repositories;
//using CRUD.API.Services;
//using FluentValidation;
//using FluentValidation.AspNetCore;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using System.Reflection;
//using MediatR;
//using CRUD.API.Validators;
//using CRUD.API.Handler.StudentHandler;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;
//using Autofac.Core;
//using Auth0.AspNetCore.Authentication;
//using System.Security.Claims;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//// Add database context
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

//// Register MediatR
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

//// Register repositories and services
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped<IStudentService, StudentService>();
//builder.Services.AddScoped<ITeacherService, TeacherService>();

//// Register FluentValidation
//builder.Services.AddControllers()
//    .AddFluentValidation(fv =>
//    {
//      fv.RegisterValidatorsFromAssemblyContaining<CreateTeacherCommandValidator>();
//      fv.RegisterValidatorsFromAssemblyContaining<CreateStudentCommandValidator>();
//    });

//// CORS configuration
//builder.Services.AddCors(options =>
//{
//  options.AddDefaultPolicy(builder =>
//  {
//    builder.WithOrigins("http://localhost:4200")
//           .AllowAnyHeader()
//           .AllowAnyMethod();
//  });
//});

//// Add authentication with JWT
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//      options.Authority = $"https://{builder.Configuration["dev-bohvwgvoj0sjydmb.us.auth0.com"]}/";
//      options.Audience = builder.Configuration["NqayQ4CtPXwddeDaqSr8yl30SBymrxm5"];
//      options.TokenValidationParameters = new TokenValidationParameters
//      {
//        NameClaimType = ClaimTypes.NameIdentifier,
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateIssuerSigningKey = true,  
//        ValidIssuer = $"https://{builder.Configuration["dev-bohvwgvoj0sjydmb.us.auth0.com"]}/",
//        ValidAudience = builder.Configuration["NqayQ4CtPXwddeDaqSr8yl30SBymrxm5"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["MExlfa09TyHvCI5fw9WdpquRsQ26FolEybO4Kzd8ai23A79r-nZdf9_ch0GUgZhz"]))
//      };
//    });

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//  app.UseSwagger();
//  app.UseSwaggerUI();
//}

//// Custom exception handling middleware
//app.UseMiddleware<ExceptionMiddleware>();

//// Add authorization and CORS middleware
//app.UseAuthentication();
//app.UseAuthorization();
//app.UseCors();

//app.MapControllers();

//app.Run();
