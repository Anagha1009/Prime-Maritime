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

        [HttpGet("GetSRRBySRRNO")]
        public ActionResult<Response<SRR>> GetSRRBySRRNo(string SRR_NO, string AGENT_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_srrService.GetSRRBySRRNo(SRR_NO, AGENT_CODE)));
        }

        [HttpGet("GetRates")]
        public ActionResult<Response<RATES>> GetRates(string POL, string POD)
        {
            return Ok(JsonConvert.SerializeObject(_srrService.GetRates(POL, POD)));
        }

        [HttpGet("GetSRRList")]
        public ActionResult<Response<List<SRRList>>> GetSRRList(string OPERATION, string SRR_NO,string CUSTOMER_NAME, string STATUS, string FROMDATE, string TODATE, string AGENT_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_srrService.GetSRRList(OPERATION,SRR_NO,CUSTOMER_NAME,STATUS,FROMDATE,TODATE, AGENT_CODE)));
        }

        [HttpPost("InsertSRR")]
        public ActionResult<Response<SRR>> InsertSRR(SRRRequest request)
        {
            return Ok(_srrService.InsertSRR(request));
        }

        [HttpPost("InsertContainer")]
        public ActionResult<Response<SRR>> InsertContainer(List<SRR_CONTAINERS> request)
        {
            return Ok(_srrService.InsertContainer(request));
        }

        [HttpPost("UploadFiles")]
        public IActionResult UploadFiles()
        {
            //List<IFormFile> x = (List<IFormFile>)Request.Form.Files;

            var formFile = Request.Form.Files;

            string path = Path.Combine("Uploads", "SRRFiles");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in formFile)
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

        [HttpPost("ApproveRate")]
        public ActionResult<Response<CommonResponse>> ApproveRate(List<SRR_RATES> request)
        {
            return Ok(_srrService.ApproveRate(request));
        }

        [HttpPost("CounterRate")]
        public ActionResult<Response<CommonResponse>> CounterRate(List<SRR_RATES> request)
        {
            return Ok(_srrService.CounterRate(request));
        }
    }
}
