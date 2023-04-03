using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Activ.EQM.API.Controllers
{
    using Activ.EQM.API.Helpers;
    using Activ.EQM.BusinessLogicAccess.InputData;
    using Activ.EQM.DataAcces.Data;
    using Activ.EQM.DataAcces.Models;
    using Activ.EQM.DataAcces.Repositories;
    using BusinessLogicAccess.Services;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Route("/[controller]")]
    [ApiController]
    public class ActionPointController : ControllerBase
    {
        EQMActionPointReporitory EQMActionPointReporitory { get; set; }

        private readonly ILogger<EqmActionPoint> _logger;
        private readonly EQMDbContext _EQMDbContext;
        public ActionPointController(ILogger<EqmActionPoint> logger, EQMDbContext EQMDbContext)
        {
            _logger = logger;
            _EQMDbContext = EQMDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            
            {
                EQMActionPointReporitory = new EQMActionPointReporitory(_logger, _EQMDbContext);
                ServiceActionPoint _service = new ServiceActionPoint(EQMActionPointReporitory);
                return Ok(_service.GetAll());
            } 
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            
            {
                EQMActionPointReporitory = new EQMActionPointReporitory(_logger, _EQMDbContext);
                ServiceActionPoint _service = new ServiceActionPoint(EQMActionPointReporitory);
                EqmActionPoint? Apm = _service.GetAll().Where(c => c.ActionPointId == id).FirstOrDefault();
                if(Apm != null)
                {
                    return Ok(Apm);  }
                else { 
                    return NotFound(); } 
            }
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            
            {
                EQMActionPointReporitory = new EQMActionPointReporitory(_logger, _EQMDbContext);
                ServiceActionPoint _service = new ServiceActionPoint(EQMActionPointReporitory);
                  _service.Delete(id);
               return Ok();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ActionPoint apm)
        {
            if (apm is null)
            {
                return BadRequest(string.Format(Const_Msg.CONST_REQUEST_CONTENT_NULL, Const_Msg.CONST_CLASS_NAME_APN));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(string.Format(Const_Msg.CONST_REQUEST_CONTENT_INVALID, Const_Msg.CONST_CLASS_NAME_APt));
            }

            
            {
                EQMActionPointReporitory = new EQMActionPointReporitory(_logger, _EQMDbContext);
                ServiceActionPoint _service = new ServiceActionPoint(EQMActionPointReporitory);
                var _apm = await _service.Add(apm);
                return Created("ActionPoint", _apm);   
            }
             
        }


        [HttpPut]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActionPoint apm)
        {
            if (apm == null)
            {
                return BadRequest(string.Format(Const_Msg.CONST_REQUEST_CONTENT_NULL, Const_Msg.CONST_CLASS_NAME_APt));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(string.Format(Const_Msg.CONST_REQUEST_CONTENT_INVALID, Const_Msg.CONST_CLASS_NAME_APt));
            }

            
            {
                EQMActionPointReporitory = new EQMActionPointReporitory(_logger, _EQMDbContext);
                ServiceActionPoint _service = new ServiceActionPoint(EQMActionPointReporitory);
                var apn = _service.GetAll().Where(c => c.ActionPointId == id);
                if (apn == null)
                {
                    return NotFound();
                }
                _service.Update(id, apm);
                apn = _service.GetAll().Where(c => c.ActionPointId == id);
                return Ok(apn);
            }

        }




    }
}
