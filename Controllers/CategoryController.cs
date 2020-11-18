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
using vocabteam.Helpers.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.IO;

namespace vocabteam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly ICategoryService _CategoryService;

        public CategoryController(IOptions<AppSettings> appSettings, ICategoryService categoryService)
        {
            this._CategoryService = categoryService;
            this._appSettings = appSettings.Value;
        }


        [HttpGet]
        public IActionResult Get()
        {
            ListCategoryModel result = null;
            try
            {
                result = new ListCategoryModel(_CategoryService.GetAll().ToList());
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
            var categoryResponse = new CategoryResponse(result, baseResponse);
            return StatusCode(200, categoryResponse);
        }

        [HttpGet("level")]
        [HttpGet("level/{levelId}")]
        public IActionResult GetByLevel(int? levelId)
        {
            ListCategoryModel result = null;
            try
            {
                if (levelId == null || levelId == 0)
                {
                    result = new ListCategoryModel(_CategoryService.GetAll().ToList());
                }
                else
                {
                    result = new ListCategoryModel(_CategoryService.GetByLevel(levelId.Value));
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
            var baseResponse = new BaseResponse((int)ConstantVar.ResponseCode.SUCCESS,
                                                    ConstantVar.ResponseString(ConstantVar.ResponseCode.SUCCESS));
            var categoryResponse = new CategoryResponse(result, baseResponse);
            return StatusCode(200, categoryResponse);
        }

        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            try
            {
                _CategoryService.Insert(model);
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
