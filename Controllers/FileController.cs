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
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly string path = "/Users/rocky/Desktop/test/";
        public FileController()
        {
        }
        [HttpGet]
        [Route("{type}/{name}")]
        public IActionResult Get(string type, string name)
        {
            string source = path + type + "/" + name;
            var image =  System.IO.File.OpenRead(source);
            return File(image, "image/jpeg");
        }


    }
}


// [HttpGet]
// public async Task<IActionResult> Get()
// {
//     var image = System.IO.File.OpenRead("C:\\test\\random_image.jpeg");
//     return File(image, "image/jpeg");
// }