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





/// BINNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN

            //  StatusCode cannot be set because the response has already started.
            // context.Response.StatusCode = 200;

            // Headers are read-only, response has already started.
            // context.Response.ContentType = "application/json";
// {
//     "code": 25,
//     "message": "access token could not be verified"
// }{
//     "code": 50,
//     "message": "fail"
// }