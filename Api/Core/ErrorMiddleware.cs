using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Api.Core
{
    public class ErrorMiddleware
    {
    
            private readonly RequestDelegate _next;

            public ErrorMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            // IMyScopedService is injected into Invoke
            public async Task Invoke(HttpContext httpContext)
            {
                try
                {
                     await _next(httpContext);
                }
                catch (Exception er)
                {
                    httpContext.Response.ContentType = "application/json";
                    object response = null;
                    var statusCode = StatusCodes.Status500InternalServerError;

                    switch(er)
                    {
                            

                        default:
                            
                        break;
                    }

                    if(response != null)
                    {
                        await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
                        return;
                    }

                    await Task.FromResult(httpContext.Response);
                }    

            }
        
    }
}
