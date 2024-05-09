using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

public class ExceptionMiddleware
{
  private readonly RequestDelegate _next;

  public ExceptionMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task Invoke(HttpContext context)
  {
    try
    {
      await _next(context);
    }
    catch (Exception ex)
    {
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = StatusCodes.Status500InternalServerError;

      var errorMessage = JsonConvert.SerializeObject(new { error = ex.Message });
      await context.Response.WriteAsync(errorMessage);
    }
  }
}
