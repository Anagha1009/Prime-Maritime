using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Request;
using PrimeMaritime_API.Response;
using System.Collections.Generic;
using System.IO;

namespace PrimeMaritime_API.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class SRRController : ControllerBase
    {

        private ISRRService _srrService;
        public SRRController(ISRRService srrService)
        {
            _srrService = srrService;
        }

        [HttpGet]
        public ActionResult<Response<SRR>> GetSRRBySRRNo(string SRR_NO)
        {
            return Ok(JsonConvert.SerializeObject(_srrService.GetSRRBySRRNo(SRR_NO)));
        }

        [HttpGet("GetSRRList")]
        public ActionResult<Response<List<SRRList>>> GetSRRList()
        {
            return Ok(JsonConvert.SerializeObject(_srrService.GetSRRList()));
        }

        [HttpPost("InsertSRR")]
        public ActionResult<Response<SRR>> InsertSRR(SRRRequest request)
        {
            return Ok(_srrService.InsertSRR(request));
        }

        [HttpPost("UploadFiles")]
        public IActionResult Index(List<IFormFile> postedFiles, string Module)
        {
            string path = Path.Combine("Uploads", Module + "Files");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);                    
                }
            }

            return Ok();
        }
    }
}
