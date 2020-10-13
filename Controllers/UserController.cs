﻿using System;
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
    [Route("[controller]")]
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
            var response = _UserService.Authenticate(model);
            if (response == null)
            {
                var failResponse = new BaseResponse((int) ConstantVar.ResponseCode.FAIL, ConstantVar.ResponseString(ConstantVar.ResponseCode.FAIL));
                return StatusCode(200, failResponse);
            }
            return StatusCode(200, response);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest model)
        {
            try
            {
                var newUserModel = _UserService.Insert(model);
                var newUserInfoResponse = new UserInfoResponse(newUserModel);
                return StatusCode(200, newUserInfoResponse);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
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
    }
}
