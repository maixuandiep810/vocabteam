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
    public class VocabularyController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IVocabularyService _VocabularyService;

        public VocabularyController(IOptions<AppSettings> appSettings, IVocabularyService vocabularyService)
        {
            this._VocabularyService = vocabularyService;
            this._appSettings = appSettings.Value;
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<Vocabulary> result = null;
            try
            {
                result = _VocabularyService.GetAll().ToList();
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
            var vocabularyResponse = new VocabularyResponse(result, baseResponse);
            return StatusCode(200, vocabularyResponse);
        }

        [HttpPost]
        public IActionResult CreateVocabulary(IFormCollection formdata)
        {

            Vocabulary newVocabulary = new Vocabulary
            {
                Word = HttpContext.Request.Form["word"],
                Meaning = HttpContext.Request.Form["meaning"],
                Sentence = HttpContext.Request.Form["sentence"],
                Definition = HttpContext.Request.Form["definition"]
            };
            try
            {
                string imageUrl = UploadFile("image", formdata);
                newVocabulary.ImageUrl = imageUrl;
                string audioUrl = UploadFile("audio", formdata);
                newVocabulary.AudioUrl = audioUrl;
                _VocabularyService.Insert(newVocabulary);
            }
            catch (CustomException ex)
            {
                if (ex.Response_Code == ConstantVar.ResponseCode.SAVING_FILE_ERROR)
                {
                    _VocabularyService.Insert(newVocabulary);
                }
                else
                {
                    var failResponse = new BaseResponse((int)ex.Response_Code,
                                                    ConstantVar.ResponseString(ex.Response_Code));
                    return StatusCode(200, failResponse);
                }

            }
            catch (Exception)
            {
                var failResponse = new BaseResponse((int)ConstantVar.ResponseCode.FAIL,
                                                    ConstantVar.ResponseString(ConstantVar.ResponseCode.FAIL));
                return StatusCode(200, failResponse);
            }
            var createResponse = new BaseResponse((int)ConstantVar.ResponseCode.CREATE_VOCABULARY_SUCCESSFULLY,
                                                    ConstantVar.ResponseString(ConstantVar.ResponseCode.CREATE_VOCABULARY_SUCCESSFULLY));
            return StatusCode(200, createResponse);
        }

        public string UploadFile(string type, IFormCollection formdata)
        {
            string fileUrl = null;
            var file = HttpContext.Request.Form.Files[type];
            var word = HttpContext.Request.Form["word"];
            string source = _appSettings.StaticFilesPath + ConstantVar.VocabularyFolder + "/" + type;
            try
            {
                if (file.Length > 0)
                {
                    string filename = word + System.IO.Path.GetExtension(file.FileName); // Give file name
                    using (var fileStream = new FileStream(Path.Combine(source, filename), FileMode.Create))
                    {
                        file.CopyToAsync(fileStream);
                    }
                    fileUrl = ConstantVar.VocabularyFolder + "/" + type + "/" + filename;
                }
            }
            catch (System.Exception)
            {
                throw new CustomException(ConstantVar.ResponseCode.SAVING_FILE_ERROR);
            }
            return fileUrl;
        }

    }
}
