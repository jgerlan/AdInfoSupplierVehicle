﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using AdInfoSupplierVehicle.API.ViewModels;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AdInfoSupplierVehicle.API.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            //TODO: Gravar log de erro com o trace id

            ErrorResponseModel errorResponseVm;

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" ||
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Qa")
            {
                errorResponseVm = new ErrorResponseModel(HttpStatusCode.InternalServerError.ToString(),
                                                      $"{ex.Message} {ex?.InnerException?.Message}");
            }
            else
            {
                //Homologação, Pre Prod, Produção...

                errorResponseVm = new ErrorResponseModel(HttpStatusCode.InternalServerError.ToString(),
                                                      "An internal server error has occurred.");
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(errorResponseVm);
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
