using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace PrimeMaritime_API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class BLController : ControllerBase
    {
        private IBLService _blService;
        private ICommonService _commonService;
        private readonly IWebHostEnvironment _environment;
        public BLController(IBLService blService, IWebHostEnvironment environment, ICommonService commonService)
        {
            _blService = blService;
            _environment = environment;
            _commonService = commonService;
        }

        [HttpPost("InsertBL")]
        public ActionResult<Response<string>> InsertBL(BL request)
        {
            return Ok(_blService.InsertBL(request));
        }

        [HttpGet("GetBLDetails")]
        public ActionResult<Response<BL>> GetBLDetails(string BL_NO, string BOOKING_NO, string AGENT_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_blService.GetBLDetails(BL_NO, BOOKING_NO, AGENT_CODE)));
        }

        [HttpGet("GetBLHistory")]
        public ActionResult<Response<List<BL>>> GetBLHistory(string AGENT_CODE, string ORG_CODE, string PORT)
        {
            return Ok(JsonConvert.SerializeObject(_blService.GetBLHistory(AGENT_CODE,ORG_CODE,PORT)));
        }

        [HttpGet("GetBLSurrenderedList")]
        public ActionResult<Response<List<BL>>> GetBLSurrenderedList(string POD, string ORG_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_blService.GetBLSurrenderedList(POD,ORG_CODE)));
        }

        [HttpGet("GetBLFORMERGE")]
        public ActionResult<Response<List<BL>>> GetBLFORMERGE(string PORT_OF_LOADING, string PORT_OF_DISCHARGE, string SHIPPER, string CONSIGNEE, string VESSEL_NAME, string VOYAGE_NO, string NOTIFY_PARTY)
        {
            return Ok(JsonConvert.SerializeObject(_blService.GetBLFORMERGE(PORT_OF_LOADING, PORT_OF_DISCHARGE, SHIPPER, CONSIGNEE, VESSEL_NAME, VOYAGE_NO, NOTIFY_PARTY)));
        }

        [HttpGet("GetSRRDetails")]
        public ActionResult<Response<SRR>> GetSRRDetails(string BL_NO, string BOOKING_NO, string AGENT_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_blService.GetSRRDetails(BL_NO, BOOKING_NO, AGENT_CODE)));
        }

        [HttpGet("GetContainerList")]
        public ActionResult<Response<List<CONTAINERS>>> GetContainerList(string AGENT_CODE, string DEPO_CODE, string BOOKING_NO, string CRO_NO,string BL_NO,string DO_NO,bool fromDO)
        {
            return Ok(JsonConvert.SerializeObject(_blService.GetContainerList(AGENT_CODE, DEPO_CODE, BOOKING_NO, CRO_NO,BL_NO,DO_NO,fromDO)));
        }

        [HttpGet("GetCargoManifestList")]
        public ActionResult<Response<CargoManifest>> GetCargoManifestList(string AGENT_CODE, string VESSEL_NAME, string VOYAGE_NO)
        {
            return Ok(JsonConvert.SerializeObject(_blService.GetCargoManifestList(AGENT_CODE, VESSEL_NAME, VOYAGE_NO)));
        }

        [HttpPost("UpdateBL")]
        public ActionResult<Response<string>> UpdateBL(BL request)
        {
            return Ok(_blService.UpdateBL(request));
        }

        [HttpGet("InsertSurrender")]
        public void InsertSurrender(string BL_NO)
        {
            _blService.InsertSurrender(BL_NO);
        }

        [HttpGet("GetBLListPM")]
        public ActionResult<Response<List<BL>>> GetBLListPM()
        {
            return Ok(JsonConvert.SerializeObject(_blService.GetBLListPM()));
        }

        [HttpGet("GetOrgDetails")]
        public ActionResult<Response<Organisation>> GetOrgDetails(string ORG_CODE, string ORG_LOC_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_blService.GetOrgDetails(ORG_CODE, ORG_LOC_CODE)));
        }

        [HttpPost("UploadBLFiles")]
        public async Task<IActionResult> UploadBLFiles(string BL_NO, [FromForm] MailRequest request)
        {
            try
            {
                await _commonService.SendEmailBLAsync(request);
                string upload = Path.Combine(_environment.ContentRootPath, "Uploads");

                if (!Directory.Exists(upload))
                {
                    Directory.CreateDirectory(upload);
                }

                string path = Path.Combine(_environment.ContentRootPath, "Uploads", "BLFiles");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                List<string> uploadedFiles = new List<string>();
                foreach (IFormFile postedFile in Request.Form.Files)
                {
                    string fileName = Path.GetFileName(BL_NO + "_" + postedFile.FileName);
                    using (FileStream stream = new FileStream(Path.Combine(_environment.ContentRootPath, path, fileName), FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                        uploadedFiles.Add(fileName);
                    }
                }

                _blService.InsertUploadedSurrender(BL_NO);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }            
        }

        [HttpGet("GetBLFiles")]
        public ActionResult<Response<List<ALL_FILE>>> GetBLFiles(string BL_NO)
        {
            string[] array1 = Directory.GetFiles("Uploads/BLFiles/");

            List<ALL_FILE> imgFiles = new List<ALL_FILE>();
            Response<List<ALL_FILE>> response = new Response<List<ALL_FILE>>();

            // Get list of files.
            List<string> filesList = array1.ToList();

            foreach (var file in filesList)
            {
                if (file.Contains(BL_NO))
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
