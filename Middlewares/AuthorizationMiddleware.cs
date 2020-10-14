using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using vocabteam.Helpers;
using vocabteam.Models.Entities;
using vocabteam.Models.Services;
using vocabteam.Models.ViewModels;
using Newtonsoft.Json;

namespace vocabteam.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IPermissionService permissionService)
        {
            var user = context.Items["User"] as User;

            if (user != null)
            {
                if (checkAuthorization(context, permissionService, user) == true)
                {
                    await _next(context);
                }
            }
            else
            {
                var failResponse = new BaseResponse((int)ConstantVar.ResponseCode.FAIL, 
                                                    ConstantVar.ResponseString(ConstantVar.ResponseCode.FAIL));
                ResponseHelper.MiddlewareResponse(context, failResponse);
                return;
            }
        }

        private bool checkAuthorization(HttpContext context, IPermissionService permissionService, User user)
        {
            try
            {
                var failResponse = new BaseResponse();
                var objectName = context.Request.Path.ToString();
                var action = context.Request.Method;
                var permissionRequest = new Permission
                {
                    ObjectName = objectName,
                    Action = action
                };
                permissionRequest = permissionService.GetByPermission(permissionRequest);

                if (permissionRequest == null)
                {
                    failResponse = new BaseResponse((int)ConstantVar.ResponseCode.PATH_DOESNOT_EXIST, 
                                                    ConstantVar.ResponseString(ConstantVar.ResponseCode.PATH_DOESNOT_EXIST));
                    ResponseHelper.MiddlewareResponse(context, failResponse);
                    return false;
                }

                bool checkPermission = permissionService.CheckPermission(permissionRequest, user);

                if (checkPermission == false)
                {
                    failResponse = new BaseResponse((int)ConstantVar.ResponseCode.PERMISSION_DENIED, 
                                                    ConstantVar.ResponseString(ConstantVar.ResponseCode.PERMISSION_DENIED));
                    ResponseHelper.MiddlewareResponse(context, failResponse);
                    return false;
                }
            }
            catch
            {
            }
            return true;
        }

    }
}
