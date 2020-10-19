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

namespace vocabteam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VocabularyController : ControllerBase
    {
        private readonly IVocabularyService _VocabularyService;

        public VocabularyController(IVocabularyService vocabularyService)
        {
            this._VocabularyService = vocabularyService;
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
            return StatusCode(200, result);
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
                _VocabularyService.Insert(newVocabulary);
                RedirectToAction("image", "File", formdata);
                RedirectToAction("audio", "File", formdata);
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
            var createResponse = new BaseResponse((int)ConstantVar.ResponseCode.CREATE_VOCABULARY_SUCCESSFULLY,
                                                    ConstantVar.ResponseString(ConstantVar.ResponseCode.CREATE_VOCABULARY_SUCCESSFULLY));
            return StatusCode(200, createResponse);
        }

    }
}
