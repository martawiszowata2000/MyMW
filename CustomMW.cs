using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMW
{
    public class CustomMW
    {
        private readonly RequestDelegate next;
        public CustomMW(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string ua = httpContext.Request.Headers["User-Agent"];
            if (ua.Contains("Edg") || ua.Contains("EdgChromium") || ua.Contains("Trident"))
            {
                httpContext.Response.WriteAsync("Przegladarka nie jest obslugiwana");
            }
            return next(httpContext);
        }
    }
}
