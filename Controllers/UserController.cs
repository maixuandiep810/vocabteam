﻿using System;
using Microsoft.AspNetCore.Mvc;
using vocabteam.Models.Services;
using vocabteam.Models.Entities;
using vocabteam.Models.ViewModels;
using vocabteam.Helpers;
using vocabteam.Helpers.CustomExceptions;

namespace vocabteam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UserController(IUserService userService)
        {
            this._UserService = userService;
        }


        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest reqModel)
        {
            UserModel result = null;
            try
            {
                var checkUser = HttpContext.Items["User"] as User;
                if (checkUser.Username.Equals(ConstantVar.RoleString(ConstantVar.Role.guest)) == false)
                {
                    throw new CustomException(ConstantVar.ResponseCode.HAVE_LOGGED);
                }
                result = _UserService.Authenticate(reqModel);
                if (result == null)
                {
                    throw new CustomException(ConstantVar.ResponseCode.USERNAME_PASSWORD_INCORRECT);
                }
            }
            catch (CustomException ex)
            {
                var failResponse = new BaseResponse((int)ex.Response_Code,
                                                    ConstantVar.ResponseString(ex.Response_Code));
                return StatusCode(200, failResponse);
            }
            catch (Exception)
            {
                var failResponse = new BaseResponse((int)ConstantVar.ResponseCode.FAIL,
                                    ConstantVar.ResponseString(ConstantVar.ResponseCode.FAIL));
                return StatusCode(200, failResponse);
            }
            var successResponse = new BaseResponse((int)ConstantVar.ResponseCode.SUCCESS,
                    ConstantVar.ResponseString(ConstantVar.ResponseCode.SUCCESS));
            var authenticateResponse = new AuthenticateResponse(result, successResponse);
            return StatusCode(200, authenticateResponse);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest model)
        {
            try
            {
                var checkUser = this.HttpContext.Items["User"] as User;
                if (checkUser.Username.Equals(ConstantVar.Role.guest.ToString()) == false)
                {
                    var failResponse = new BaseResponse((int)ConstantVar.ResponseCode.HAVE_LOGGED_DONT_NEED_TO_REGISTER,
                                                        ConstantVar.ResponseString(ConstantVar.ResponseCode.HAVE_LOGGED_DONT_NEED_TO_REGISTER));
                    return StatusCode(200, failResponse);
                }
                if (checkUser != null)
                {
                    var failResponse = new BaseResponse((int)ConstantVar.ResponseCode.EXISTED_USERNAME,
                                                        ConstantVar.ResponseString(ConstantVar.ResponseCode.EXISTED_USERNAME));
                    return StatusCode(200, failResponse);
                }
                checkUser = _UserService.FindUserByUsername(model.Username);
                var newUserModel = _UserService.Insert(model);
                var newUserInfoResponse = new UserInfoResponse(newUserModel);
                return StatusCode(200, newUserInfoResponse);
            }
            catch (CustomException ex)
            {
                var failResponse = new BaseResponse((int)ex.Response_Code,
                                                    ConstantVar.ResponseString(ex.Response_Code));
                return StatusCode(200, failResponse);
            }
            catch (Exception)
            {
                var failResponse = new BaseResponse((int)ConstantVar.ResponseCode.FAIL,
                                                    ConstantVar.ResponseString(ConstantVar.ResponseCode.FAIL));
                return StatusCode(200, failResponse);
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            try
            {
                var user = HttpContext.Items["User"] as User;
                _UserService.Logout(user);
            }
            catch (CustomException ex)
            {
                var failResponse = new BaseResponse((int)ex.Response_Code,
                                                    ConstantVar.ResponseString(ex.Response_Code));
                return StatusCode(200, failResponse);
            }
            catch (Exception)
            {
                var failResponse = new BaseResponse((int)ConstantVar.ResponseCode.FAIL,
                                    ConstantVar.ResponseString(ConstantVar.ResponseCode.FAIL));
                return StatusCode(200, failResponse);
            }
            var logoutResponse = new BaseResponse((int)ConstantVar.ResponseCode.SUCCESS,
                    ConstantVar.ResponseString(ConstantVar.ResponseCode.SUCCESS));
            return StatusCode(200, logoutResponse);

        }


    }
}






// [HttpGet]
// public IActionResult Get()
// {
//     // User u = _UserService.GetById(1);
//     // return Ok(_UserService.GetRolesOfUser(u));
//     var a = _UserService.GetAll_WithRoles();
//     return Ok(_UserService.GetAll_WithRoles());
// }