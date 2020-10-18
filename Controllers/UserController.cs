using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using vocabteam.Models.Services;
using vocabteam.Models.Entities;
using vocabteam.Models.ViewModels;
using vocabteam.Helpers;

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
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var checkUser = HttpContext.Items["User"] as User;
            if (checkUser.Username.Equals(ConstantVar.Role.guest.ToString()) == false)
            {
                var failResponse = new BaseResponse((int)ConstantVar.ResponseCode.HAVE_LOGGED, ConstantVar.ResponseString(ConstantVar.ResponseCode.HAVE_LOGGED));
                return StatusCode(200, failResponse);
            }
            var response = _UserService.Authenticate(model);
            if (response == null)
            {
                var failResponse = new BaseResponse((int)ConstantVar.ResponseCode.FAIL, ConstantVar.ResponseString(ConstantVar.ResponseCode.FAIL));
                return StatusCode(200, failResponse);
            }
            return StatusCode(200, response);
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
            catch (RepositoryException001 ex)
            {
                var failResponse = new BaseResponse((int)ConstantVar.ResponseCode.SYSTEM_ERROR,
                                                    ConstantVar.ResponseString(ConstantVar.ResponseCode.SYSTEM_ERROR));
                return StatusCode(200, failResponse);
            }
            catch (Exception ex)
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
            catch (RepositoryException001 ex)
            {
                var failResponse = new BaseResponse((int)ConstantVar.ResponseCode.SYSTEM_ERROR,
                                                    ConstantVar.ResponseString(ConstantVar.ResponseCode.SYSTEM_ERROR));
                return StatusCode(200, failResponse);
            }
            catch (Exception ex)
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