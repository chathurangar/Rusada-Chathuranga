using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rusada.DTO;
using Rusada.Entity.Entities;
using Rusada.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Rasuda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SightController : ControllerBase
    {
        private readonly ISightService _sightService;
        private readonly IWebHostEnvironment _env;

        public SightController(ISightService sightService, IWebHostEnvironment env)
        {
            _sightService = sightService;
            _env = env;
        }

        [HttpGet]
        [Route("GetAllSightDetails")]
        public async Task<ActionResult<List<SightDetailsDto>>> Get()
        {
            return await _sightService.GetAllSightDetails();
        }

        [HttpPost]
        [Route("InsertSight")]
        public async Task<bool> Post(SightDetailsDto sight)
        {
            return await _sightService.AddUpdateSight(sight);
        }

        [HttpGet]
        [Route("GetSightById/{id}")]
        public async Task<ActionResult<SightDetailsDto>> GetById(int id)
        {
            return await _sightService.GetSightById(id);
        }

        [HttpPut]
        [Route("UpdateSight")]
        public async Task<bool> Put(SightDetailsDto sight)
        {
            return await _sightService.AddUpdateSight(sight);
        }

        [HttpDelete]
        [Route("DeleteSight/{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _sightService.DeleteSight(id);
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFIle = httpRequest.Files[0];
                string fileName = postedFIle.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + fileName;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFIle.CopyTo(stream);
                }

                return new JsonResult(fileName);

            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }
    }
}
