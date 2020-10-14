using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using vocabteam.Models.ViewModels;

namespace vocabteam.Helpers
{
    public static class ResponseHelper
    {
        public static async void MiddlewareResponse(HttpContext context, BaseResponse baseResponse)
        {
            context.Response.StatusCode = 200;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(baseResponse));
        }
    }
}