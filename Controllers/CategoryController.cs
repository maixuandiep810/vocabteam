using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using vocabteam.Models.Services;
using vocabteam.Models.ViewModels;
using vocabteam.Helpers;
using vocabteam.Helpers.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.IO;
using vocabteam.Models.Entities;

namespace vocabteam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly ICategoryService _CategoryService;
        private readonly IUserCategoryService _UserCategoryService;

        public CategoryController(IOptions<AppSettings> appSettings, ICategoryService categoryService, IUserCategoryService userCategoryService)
        {
            this._CategoryService = categoryService;
            this._UserCategoryService = userCategoryService;
            this._appSettings = appSettings.Value;
        }


        [HttpGet("{userId}/{levelIdValue}/{isDifficultValue}/{isTodoTestValue}")]
        public IActionResult Get(int userId, int levelIdValue, int isDifficultValue, int isTodoTestValue)
        {
            ListUserCategoryModel result = null;
            try
            {
                result = new ListUserCategoryModel(_UserCategoryService.GetByUser(userId, levelIdValue, isDifficultValue, isTodoTestValue));
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
            var userCategoryResponse = new UserCategoryResponse(result, baseResponse);
            return StatusCode(200, userCategoryResponse);
        }

        [HttpPost]
        public IActionResult Create(IFormCollection formdata)
        {
            CategoryModel cateModel = new CategoryModel
            {
                Name = HttpContext.Request.Form["Name"],
                Description = HttpContext.Request.Form["Description"],
                ImageUrl = ""
            };
            UserCategory userCate = new UserCategory();
            userCate.IsCustomCategory = true;
            userCate.IsDifficult = Convert.ToBoolean(HttpContext.Request.Form["IsDifficult"]);
            userCate.UserId = Convert.ToInt32(HttpContext.Request.Form["UserId"]);
            try
            {
                string imageUrl = UploadFile(formdata);
                cateModel.ImageUrl = imageUrl;
                userCate.CategoryId = _CategoryService.Insert(cateModel);
                _UserCategoryService.Insert(userCate);
            }
            catch (CustomException ex)
            {
                switch (ex.Response_Code)
                {
                    case ConstantVar.ResponseCode.SAVING_FILE_ERROR:
                        userCate.CategoryId = _CategoryService.Insert(cateModel);
                        try
                        {
                            _UserCategoryService.Insert(userCate);
                        }
                        catch (CustomException ex1)
                        {
                            var failResponse1 = new BaseResponse((int)ex.Response_Code, ConstantVar.ResponseString(ex.Response_Code));
                            return StatusCode(200, failResponse1);
                        }
                        catch (Exception ex2)
                        {
                            throw;
                        }
                        break;
                    default:
                        var failResponse = new BaseResponse((int)ex.Response_Code,
                                    ConstantVar.ResponseString(ex.Response_Code));
                        return StatusCode(200, failResponse);
                }
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

        public string UploadFile(IFormCollection formdata)
        {
            string fileUrl = null;
            var file = HttpContext.Request.Form.Files["Image"];
            string source = _appSettings.StaticFilesPath + ConstantVar.CategoryFolder + "/" + "image";
            var name = HttpContext.Request.Form["Name"];
            try
            {
                if (file.Length > 0)
                {
                    string filename = name + System.IO.Path.GetExtension(file.FileName); // Give file name
                    using (var fileStream = new FileStream(Path.Combine(source, filename), FileMode.Create))
                    {
                        file.CopyToAsync(fileStream);
                    }
                    fileUrl = ConstantVar.CategoryFolder + "/" + "image" + "/" + filename;
                }
            }
            catch (System.Exception ex)
            {
                throw new CustomException(ConstantVar.ResponseCode.SAVING_FILE_ERROR);
            }
            return fileUrl;
        }

        [HttpGet("numberofcategory/{userId}")]
        public IActionResult GetNumberOfCategory(int userId)
        {
            try
            {
                
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











// [HttpGet("{userId}")]
// public IActionResult Get(int userId)
// {
//     ListCategoryModel result = null;
//     try
//     {
//         result = new ListCategoryModel(_CategoryService.GetAll(userId).ToList());
//     }
//     catch (CustomException ex)
//     {
//         var failResponse = new BaseResponse((int)ex.Response_Code,
//                                             ConstantVar.ResponseString(ex.Response_Code));
//         return StatusCode(200, failResponse);
//     }
//     catch (Exception)
//     {
//         var failResponse = new BaseResponse((int)ConstantVar.ResponseCode.FAIL,
//                                             ConstantVar.ResponseString(ConstantVar.ResponseCode.FAIL));
//         return StatusCode(200, failResponse);
//     }
//     var baseResponse = new BaseResponse((int)ConstantVar.ResponseCode.SUCCESS,
//                                             ConstantVar.ResponseString(ConstantVar.ResponseCode.SUCCESS));
//     var categoryResponse = new CategoryResponse(result, baseResponse);
//     return StatusCode(200, categoryResponse);
// }