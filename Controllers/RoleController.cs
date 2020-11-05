using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using vocabteam.Models.Services;
using vocabteam.Models.ViewModels;
using vocabteam.Helpers;
using vocabteam.Helpers.CustomExceptions;
using Microsoft.Extensions.Options;

namespace vocabteam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IRoleService _RoleService;

        public RoleController(IOptions<AppSettings> appSettings, IRoleService roleService)
        {
            _RoleService = roleService;
            _appSettings = appSettings.Value;
        }


        [HttpGet]
        public IActionResult Get()
        {
            ListRoleModel result = null;
            try
            {
                result = new ListRoleModel(_RoleService.GetAll().ToList());
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
            var baseResponse = new BaseResponse((int)ConstantVar.ResponseCode.SUCCESS,
                                                    ConstantVar.ResponseString(ConstantVar.ResponseCode.SUCCESS));
            var roleResponse = new RoleResponse(result, baseResponse);
            return StatusCode(200, roleResponse);
        }
        
        [HttpPost("nuser_nrole")]
        public IActionResult Add_NUser_NRole(Add_NUser_NRoleRequest reqModel)
        {
            try
            {
                _RoleService.Add_NUser_NRole(reqModel);
            }
            catch (CustomException ex)
            {
                var failResponse = new BaseResponse((int)ex.Response_Code,
                                                    ConstantVar.ResponseString(ex.Response_Code));
                return StatusCode(200, failResponse);
            }
            catch (Exception ex)
            {
                var failResponse = new BaseResponse((int)ConstantVar.ResponseCode.FAIL,
                                                    ConstantVar.ResponseString(ConstantVar.ResponseCode.FAIL));
                return StatusCode(200, failResponse);
            }
            var baseResponse = new BaseResponse((int)ConstantVar.ResponseCode.SUCCESS,
                                                    ConstantVar.ResponseString(ConstantVar.ResponseCode.SUCCESS));
            return StatusCode(200, baseResponse);
        }

    }
}
