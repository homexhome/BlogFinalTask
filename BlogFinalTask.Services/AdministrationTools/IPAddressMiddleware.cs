using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFinalTask.Services.AdministrationTools
{
    public class IPAddressMiddleware
    {
        private readonly RequestDelegate _next;
        public IPAddressMiddleware(RequestDelegate next) {
            _next = next;
        }
        public async Task Invoke(HttpContext context) {
            string? ipAddress = context.Connection.RemoteIpAddress?.ToString();

            context.Items["ClientIPAddress"] = ipAddress;

            await _next(context);
        }
    }
    public static class IPAddressMiddlewareExtensions
    {
        public static IApplicationBuilder UseIPAddressMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<IPAddressMiddleware>();
        }
    }
}
