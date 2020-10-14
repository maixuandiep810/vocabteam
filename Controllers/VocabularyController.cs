using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using vocabteam.Models.Services;
using vocabteam.Models.Entities;
using vocabteam.Models.ViewModels;

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
            return StatusCode(200, _VocabularyService.GetAll().ToList());
        }

    }
}
