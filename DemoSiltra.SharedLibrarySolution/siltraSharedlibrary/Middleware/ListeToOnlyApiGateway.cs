using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siltraSharedlibrary.Middleware
{
    
    public class ListeToOnlyApiGateway(RequestDelegate next)
    {

        public async Task InvokeAsync(HttpContext context)
        {

            // buscamos el encabezado de la peticion
            var singHeader = context.Request.Headers["Api-Gateway"];

            // if NULL la request no esta viniendo de la API Gateway, entonces ignoramos
            if (singHeader.FirstOrDefault() == null)
            {
                //Mandamos 503 para denegar el servicio

                context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                await context.Response.WriteAsync("Lo sentimos el servicio no esta disponible");
                return;
            }
            else
            {
                await next(context);
            }
        }
    }
}
