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
    public class ProcessController : ControllerBase
    {
        EQMProcessReporitory EQMProcessReporitory { get; set; }
        private readonly EQMDbContext _EQMDbContext;

        private readonly ILogger<EqmProcess> _logger;

        public ProcessController(ILogger<EqmProcess> logger, EQMDbContext EQMDbContext)
        {
            _logger = logger;
            _EQMDbContext = EQMDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
           
            {
                EQMProcessReporitory = new EQMProcessReporitory(_logger, _EQMDbContext);
                ServiceProcess _service = new ServiceProcess(EQMProcessReporitory);
                return Ok(_service.GetAll());
            } 
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
           
            {
                EQMProcessReporitory = new EQMProcessReporitory(_logger, _EQMDbContext);
                ServiceProcess _service = new ServiceProcess(EQMProcessReporitory);
                EqmProcess? Apm = _service.GetAll().Where(c => c.ProcessId == id).FirstOrDefault();
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
                EQMProcessReporitory = new EQMProcessReporitory(_logger, _EQMDbContext);
                ServiceProcess _service = new ServiceProcess(EQMProcessReporitory);
                  _service.Delete(id);
               return Ok();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Process apm)
        {
            if (apm is null)
            {
                return BadRequest(string.Format(Const_Msg.CONST_REQUEST_CONTENT_NULL, Const_Msg.CONST_CLASS_NAME_APN));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(string.Format(Const_Msg.CONST_REQUEST_CONTENT_INVALID, Const_Msg.CONST_CLASS_NAME_P));
            }

            
            {
                EQMProcessReporitory = new EQMProcessReporitory(_logger, _EQMDbContext);
                ServiceProcess _service = new ServiceProcess(EQMProcessReporitory);
                var _apm = await _service.Add(apm);
                return Created("Process", _apm);   
            }
             
        }



        [HttpPut]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Process apm)
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
                EQMProcessReporitory = new EQMProcessReporitory(_logger, _EQMDbContext);
                ServiceProcess _service = new ServiceProcess(EQMProcessReporitory);
                var apn = _service.GetAll().Where(c => c.ProcessId == id);
                if (apn == null)
                {
                    return NotFound();
                }
                _service.Update(id, apm);
                apn = _service.GetAll().Where(c => c.ProcessId == id);
                return Ok(apn);
            }

        }




    }
}
