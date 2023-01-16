using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
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
using System.Linq;

namespace PrimeMaritime_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRRController : ControllerBase
    {

        private ISRRService _srrService;
        private readonly IWebHostEnvironment _environment;
        public SRRController(ISRRService srrService, IWebHostEnvironment environment)
        {
            _srrService = srrService;
            _environment = environment;
        }

        [HttpGet("GetSRRBySRRNO")]
        public ActionResult<Response<SRR>> GetSRRBySRRNo(string SRR_NO, string AGENT_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_srrService.GetSRRBySRRNo(SRR_NO, AGENT_CODE)));
        }

        [HttpGet("GetRate")]
        public ActionResult<Response<string>> GetRates(string POL, string POD, string CHARGE, string CONT_TYPE)
        {
            return Ok(JsonConvert.SerializeObject(_srrService.GetRate(POL, POD, CHARGE, CONT_TYPE)));
        }

        [HttpGet("GetCalRates")]
        public ActionResult<Response<RATES>> GetCalRates(string POL, string POD, string CONTAINER_TYPE, string SRR_NO, int NO_OF_CONTAINERS)
        {
            return Ok(JsonConvert.SerializeObject(_srrService.GetCalRates(POL, POD, CONTAINER_TYPE, SRR_NO, NO_OF_CONTAINERS)));
        }

        [HttpGet("GetSRRList")]
        public ActionResult<Response<List<SRRList>>> GetSRRList(string OPERATION, string SRR_NO, string CUSTOMER_NAME, string STATUS, string FROMDATE, string TODATE, string AGENT_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_srrService.GetSRRList(OPERATION, SRR_NO, CUSTOMER_NAME, STATUS, FROMDATE, TODATE, AGENT_CODE)));
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
        public IActionResult UploadFiles(string SRR_NO)
        {

            string path = Path.Combine(_environment.ContentRootPath, "Uploads", "SRRFiles");
            string HAZpath = Path.Combine(_environment.ContentRootPath, "Uploads", "SRRFiles/HAZFiles");
            string FLEXIBAGpath = Path.Combine(_environment.ContentRootPath, "Uploads", "SRRFiles/FLEXIBAGFiles");
            string SPpath = Path.Combine(_environment.ContentRootPath, "Uploads", "SRRFiles/SPFiles");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (!Directory.Exists(HAZpath))
            {
                Directory.CreateDirectory(HAZpath);
            }
            else if (!Directory.Exists(FLEXIBAGpath))
            {
                Directory.CreateDirectory(FLEXIBAGpath);
            }
            else if (!Directory.Exists(SPpath))
            {
                Directory.CreateDirectory(SPpath);
            }

            foreach (var key in Request.Form.Keys)
            {
                var data = Request.Form[key];

                for (int i = 0; i < data.Count; i++)
                {
                    string fileName = Path.GetFileName(SRR_NO + "_" + Request.Form.Files[i].FileName);
                    if (data[i] == "HAZ")
                    {
                        using (FileStream stream = new FileStream(Path.Combine(_environment.ContentRootPath, HAZpath, fileName), FileMode.Create))
                        {
                            Request.Form.Files[i].CopyTo(stream);
                        }
                    }
                    else if (data[i] == "FLEXIBAG")
                    {
                        using (FileStream stream = new FileStream(Path.Combine(_environment.ContentRootPath, FLEXIBAGpath, fileName), FileMode.Create))
                        {
                            Request.Form.Files[i].CopyTo(stream);
                        }
                    }
                    else if (data[i] == "SP")
                    {
                        using (FileStream stream = new FileStream(Path.Combine(_environment.ContentRootPath, SPpath, fileName), FileMode.Create))
                        {
                            Request.Form.Files[i].CopyTo(stream);
                        }
                    }
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

        [HttpGet("GetSRRFiles")]
        public ActionResult<Response<List<ALL_FILE>>> GetSRRFiles(string SRR_NO)
        {
            string[] array1 = Directory.GetFiles("Uploads/SRRFiles");

            List<ALL_FILE> imgFiles = new List<ALL_FILE>();
            Response<List<ALL_FILE>> response = new Response<List<ALL_FILE>>();

            // Get list of files.
            List<string> filesList = array1.ToList();

            foreach (var file in filesList)
            {
                if (file.Contains(SRR_NO))
                {
                    ALL_FILE img = new ALL_FILE();
                    long length = new System.IO.FileInfo(file).Length / 1024;
                    img.FILE_NAME = file.Split('/')[2];
                    img.FILE_SIZE = length.ToString() + "KB";
                    img.FILE_PATH = file;

                    imgFiles.Add(img);

                }
            }

            if (imgFiles.Count > 0)
            {
                response.Succeeded = true;
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                response.Data = imgFiles;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }
            return response;
        }
    }
}
