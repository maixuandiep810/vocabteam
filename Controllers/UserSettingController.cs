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
    public class UserSettingController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IUserSettingService _userSettingService;

        public UserSettingController(IOptions<AppSettings> appSettings, IUserSettingService userSettingService)
        {
            _userSettingService = userSettingService;
            _appSettings = appSettings.Value;
        }


        [HttpGet("testsetting/{userId}")]
        public IActionResult Get(int userId)
        {
            ListTestSettingModel result = null;
            try
            {
                result = new ListTestSettingModel(_userSettingService.GetSetting_ToDoTest(userId));
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
            var roleResponse = new TestSettingResponse(result, baseResponse);
            return StatusCode(200, roleResponse);
        }
        
    }
}
