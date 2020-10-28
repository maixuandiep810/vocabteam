using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using vocabteam.Helpers;
using vocabteam.Helpers.CustomExceptions;
using vocabteam.Models.Entities;
using vocabteam.Models.Services;
using vocabteam.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
                try
                {
                    if (checkAuthorization(context, permissionService, user) == true)
                    {
                        await _next(context);
                    }
                }
                catch (CustomException ex)
                {
                    var failResponse = new BaseResponse((int)ex.Response_Code,
                                                        ConstantVar.ResponseString(ex.Response_Code));
                    ResponseHelper.MiddlewareResponse(context, failResponse);
                }
                catch (System.Exception)
                {
                    var failResponse = new BaseResponse((int)ConstantVar.ResponseCode.FAIL,
                                                        ConstantVar.ResponseString(ConstantVar.ResponseCode.FAIL));
                    ResponseHelper.MiddlewareResponse(context, failResponse);
                }
            }
        }

        private bool checkAuthorization(HttpContext context, IPermissionService permissionService, User user)
        {
            try
            {
                var failResponse = new BaseResponse();
                var objectName = context.Request.Path.ToString();
                var action = context.Request.Method;
                var permissionRequest = new Permission()
                {
                    ObjectName = objectName,
                    Action = action
                };

                // FILE PERMISSION ok ?????
                List<Permission> permissionConfirm = permissionService.GetByPermission(permissionRequest);
                if (permissionConfirm == null)
                {
                    throw new CustomException(ConstantVar.ResponseCode.REQUEST_DOESNOT_EXIST);
                }

                bool checkPermission = permissionService.CheckPermission(permissionConfirm, user);
                if (checkPermission == false)
                {
                    throw new CustomException(ConstantVar.ResponseCode.PERMISSION_DENIED);
                }
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

    }
}
