using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DotNetCorePoc.Api.BusinessServices;
using DotNetCorePoc.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCorePoc.Api.Controllers
{
    [ApiController]
    [Route("api/excel/upload")]
    public class UploadController : Controller
    {
        private readonly IUploadBusinessService _uploadBusinessService;

        public UploadController(IUploadBusinessService uploadBusinessService)
        {
            _uploadBusinessService = uploadBusinessService ?? throw new ArgumentNullException(nameof(uploadBusinessService));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetSample()
        {
            return Ok("Test");
        }
        [HttpPost]
        [Route("")]
        public async Task<ExcelResponseModel> Upload([FromBody] ExcelUploadModel model)
        {
            return await _uploadBusinessService.Upload(model);
        }
    }
}
