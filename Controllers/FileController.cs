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
using Microsoft.Extensions.Options;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace vocabteam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        public FileController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        // [HttpPost]
        // [Route("vocabulary/{type}")]
        // public IActionResult UploadFile(string type, IFormCollection formdata)
        // {
        //     var failResponse = new BaseResponse();
        //     try
        //     {
        //         var file = HttpContext.Request.Form.Files[type];
        //         var word = HttpContext.Request.Form["word"];
        //         string source = _appSettings.StaticFilesPath + "/" + type;
        //         if (file.Length > 0)
        //         {
        //             string filename = word + System.IO.Path.GetExtension(file.FileName); // Give file name
        //             using (var fileStream = new FileStream(Path.Combine(source, filename), FileMode.Create))
        //             {
        //                 file.CopyToAsync(fileStream);
        //             }
        //         }
        //     }
        //     catch (System.Exception ex)
        //     {
        //         failResponse = new BaseResponse((int)ConstantVar.ResponseCode.FAIL, ex.Message);
        //         return StatusCode(200, failResponse);
        //     }
        //     var response = new BaseResponse((int)ConstantVar.ResponseCode.SUCCESS, ConstantVar.ResponseString(ConstantVar.ResponseCode.SUCCESS));
        //     return StatusCode(200, response); ;
        // }

    }
}


// [HttpGet]
// public async Task<IActionResult> Get()
// {
//     var image = System.IO.File.OpenRead("C:\\test\\random_image.jpeg");
//     return File(image, "image/jpeg");
// }




















// [HttpGet]
// [Route("{type}/{name}")]
// public IActionResult DownloadFile(string type, string name)
// {
//     type = type.ToLower();
//     string source = _appSettings.StaticFilesPath + type + "/" + name;
//     var failResponse = new BaseResponse();
//     if (System.IO.File.Exists(source) == false)
//     {
//         failResponse = new BaseResponse((int)ConstantVar.ResponseCode.FAIL, ConstantVar.ResponseString(ConstantVar.ResponseCode.FAIL));
//         return StatusCode(200, failResponse);
//     }

//     try
//     {
//         var image = System.IO.File.OpenRead(source);
//         switch (type)
//         {
//             case "image":
//                 return File(image, "image/jpeg");
//             default:
//                 break;
//         }
//     }
//     catch (System.Exception)
//     {
//         failResponse = new BaseResponse((int)ConstantVar.ResponseCode.FAIL, ConstantVar.ResponseString(ConstantVar.ResponseCode.FAIL));
//         return StatusCode(200, failResponse);
//     }

//     failResponse = new BaseResponse((int)ConstantVar.ResponseCode.FAIL, ConstantVar.ResponseString(ConstantVar.ResponseCode.FAIL));
//     return StatusCode(200, failResponse);
// }