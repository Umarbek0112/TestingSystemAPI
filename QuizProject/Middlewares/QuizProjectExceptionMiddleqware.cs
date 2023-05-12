using Microsoft.AspNetCore.Http;
using QuizProject.Service.Exceptions;
using System.Threading.Tasks;
using System;

namespace QuizProject.Middlewares
{
    public class QuizProjectExceptionMiddleqware
    {
        private readonly RequestDelegate _next;

        public QuizProjectExceptionMiddleqware(RequestDelegate next )
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(QuizProjectException ex)
            {
                await WriteException(context, ex.Code, ex.Message);
            }
            catch(Exception ex) 
            {
               await WriteException(context, 500, ex.Message);
            }
                      
        }
        public async Task WriteException (HttpContext context, int code, string massage)
        {
            context.Response.StatusCode = code;
            await context.Response.WriteAsJsonAsync(new 
            {
                Code = code,
                massage = massage
            });
        }
    }
}
