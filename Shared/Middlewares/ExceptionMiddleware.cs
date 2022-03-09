using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Havbruksloggen_Coding_Challenge.Shared.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Havbruksloggen_Coding_Challenge.Shared.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async System.Threading.Tasks.Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                string exceptionMessage = exception?.Message;

                switch (exception)
                {
                    case DuplicateException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case NotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        exceptionMessage = "Your request couldn't be processed due to an internal error";
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = exceptionMessage });
                await response.WriteAsync(result);
            }
        }
    }
}
