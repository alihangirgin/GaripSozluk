using GaripSozluk.Business.Interfaces;
using GaripSozluk.Data.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.WebApp.Extensions
{
    public class ExecutionTimeMiddleware
    {
        private readonly RequestDelegate _next;

        public ExecutionTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context ,ILogService logService)
        {
            if (context.Request.Path.HasValue)
            {
                var log = new Log();
                log.RequestPath = context.Request.Path.Value.ToString();
                log.RequestMethod = context.Request.Method.ToString();
                log.TraceIdentifier = context.TraceIdentifier.ToString();
                log.UserAgent = context.Request.Headers["User-Agent"].ToString();
                log.IPAddress = context.Connection.RemoteIpAddress.ToString();
                log.RoutePath = context.Request.QueryString.Value.ToString();
                log.ResponseStatusCode = context.Response.StatusCode.ToString();
                log.CreateDate = DateTime.Now;

                logService.AddLog(log);
                

                await _next(context);
            }

        }
    }
}
