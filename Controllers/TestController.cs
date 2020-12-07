using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using vocabteam.Models.Services;
using vocabteam.Models.Entities;
using vocabteam.Models.ViewModels;
using vocabteam.Helpers;
using vocabteam.Helpers.CustomExceptions;
using System.Collections.Generic;

namespace vocabteam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly ITestService _TestService;

        public TestController(IOptions<AppSettings> appSettings, ITestService testService)
        {
            this._TestService = testService;
            this._appSettings = appSettings.Value;
        }


        [HttpPost]
        [Route("finish")]
        public IActionResult Finish(Test model)
        {
            try
            {
                _TestService.InsertIncludeOrder(model);
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
            return StatusCode(200, baseResponse);
        }


        [HttpGet("gettest/{userId}/{categoryId}")]
        public IActionResult GetTest(int userId, int categoryId)
        {
            ListTestModel result = null;
            try
            {
                List<Test> tests = _TestService.GetTest(userId, categoryId);
                result = new ListTestModel(tests);
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
            var res = new GetTestResponse(result, baseResponse);
            return StatusCode(200, res);
        }

        
    }
}
