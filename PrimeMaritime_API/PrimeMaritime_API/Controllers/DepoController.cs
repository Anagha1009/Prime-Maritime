using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepoController : ControllerBase
    {
        private IDepoService _depoService;
        public DepoController(IDepoService depoService)
        {
            _depoService = depoService;
        }

        [HttpPost("InsertContainer")]
        public ActionResult<Response<CommonResponse>> InsertContainer(DEPO_CONTAINER request)
        {
            return Ok(_depoService.InsertContainer(request));
        }

        [HttpPost("InsertMRRequest")]
        public ActionResult<Response<CommonResponse>> InsertMRRequest(List<MR_LIST> request)
        {
            return Ok(_depoService.InsertMRRequest(request));
        }

        [HttpGet("GetMNRList")]
        public ActionResult<Response<List<MNR_LIST>>> GetMNRList(string OPERATION, string DEPO_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_depoService.GetMNRList(OPERATION, DEPO_CODE)));
        }

        [HttpGet("GetMNRDescription")]
        public ActionResult<Response<string>> GetMNRDescription(string IST_CHARACTER, string IIND_CHARACTER, string IIIRD_CHARACTER, string IVTH_CHARACTER, string COMPONENT_CODE, string DAMAGE_CODE, string REPAIR_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_depoService.GetMNRDesc(IST_CHARACTER, IIND_CHARACTER, IIIRD_CHARACTER, IVTH_CHARACTER, COMPONENT_CODE, DAMAGE_CODE, REPAIR_CODE)));
        }

        [HttpGet("GetMRDetails")]
        public ActionResult<Response<List<MR_LIST>>> GetMRDetails(string MR_NO)
        {
            return Ok(JsonConvert.SerializeObject(_depoService.GetMNRDetails(MR_NO)));
        }

        [HttpPost("ApproveRate")]
        public ActionResult<Response<CommonResponse>> ApproveRate(List<MR_LIST> request)
        {
            return Ok(_depoService.ApproveRate(request));
        }

        [HttpPost("UploadMNRFiles")]
        public IActionResult UploadMNRFiles(string MR_NO)
        {
            var formFile = Request.Form.Files;

            string path = Path.Combine("Uploads", "MNRFiles");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in formFile)
            {
                string fileName = Path.GetFileName(MR_NO + "_" + postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                }
            }

            return Ok();
        }

        //[HttpGet("GetImage")]
        //public HttpResponseMessage GetImage(string fileName)
        //{

        //    string filePath = Path.Combine("Uploads", "MNRFiles");
        //    if (!Directory.Exists(filePath))
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.NotFound);
        //    }
        //    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        //    response.Content = new StreamContent(new FileStream(Path.Combine(filePath, fileName), FileMode.Open, FileAccess.Read));
        //    response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
        //    response.Content.Headers.ContentDisposition.FileName = Path.GetFileName(fileName);
        //    response.Content.Headers.ContentLength = Path.Combine(filePath, fileName).Length;
        //    response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/*");
        //    return response;
        //}

    }
}
