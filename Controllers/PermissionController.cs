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
    public class PermissionController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IPermissionService _PermissionService;

        public PermissionController(IOptions<AppSettings> appSettings, IPermissionService permissionService)
        {
            this._PermissionService = permissionService;
            this._appSettings = appSettings.Value;
        }


        [HttpGet]
        public IActionResult Get()
        {
            ListPermissionModel result = null;
            try
            {
                result = new ListPermissionModel(_PermissionService.GetAll().ToList());
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
            var permissionResponse = new PermissionResponse(result, baseResponse);
            return StatusCode(200, permissionResponse);
        }
        
        [HttpPost("1permission_nrole")]
        public IActionResult Add1PermissionNRole(Add_NRole_NPermissonRequest reqModel)
        {
            try
            {
                _PermissionService.Add_NRole_NPermisson(reqModel);
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
