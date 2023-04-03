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
    public class AuditController : ControllerBase
    {
        EQMAuditReporitory EQMAuditReporitory { get; set; }

        private readonly EQMDbContext _EQMDbContext;
        private readonly ILogger<EqmAudit> _logger;

        public AuditController(ILogger<EqmAudit> logger, EQMDbContext EQMDbContext)
        {
            _logger = logger;
            _EQMDbContext = EQMDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            
            {
                EQMAuditReporitory = new EQMAuditReporitory(_logger, _EQMDbContext);
                ServiceAudit _service = new ServiceAudit(EQMAuditReporitory);
                return Ok(_service.GetAll());
            } 
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            
            {
                EQMAuditReporitory = new EQMAuditReporitory(_logger, _EQMDbContext);
                ServiceAudit _service = new ServiceAudit(EQMAuditReporitory);
                EqmAudit? Apm = _service.GetAll().Where(c => c.AuditId == id).FirstOrDefault();
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
                EQMAuditReporitory = new EQMAuditReporitory(_logger, _EQMDbContext);
                ServiceAudit _service = new ServiceAudit(EQMAuditReporitory);
                  _service.Delete(id);
               return Ok();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Audit apm)
        {
            if (apm is null)
            {
                return BadRequest(string.Format(Const_Msg.CONST_REQUEST_CONTENT_NULL, Const_Msg.CONST_CLASS_NAME_APN));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(string.Format(Const_Msg.CONST_REQUEST_CONTENT_INVALID, Const_Msg.CONST_CLASS_NAME_A));
            }

            
            {
                EQMAuditReporitory = new EQMAuditReporitory(_logger, _EQMDbContext);
                ServiceAudit _service = new ServiceAudit(EQMAuditReporitory);
                var _apm = await _service.Add(apm);
                return Created("Audit", _apm);   
            }
             
        }



        [HttpPut]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Audit apm)
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
                EQMAuditReporitory = new EQMAuditReporitory(_logger, _EQMDbContext);
                ServiceAudit _service = new ServiceAudit(EQMAuditReporitory);
                var apn = _service.GetAll().Where(c => c.AuditId == id);
                if (apn == null)
                {
                    return NotFound();
                }
                _service.Update(id, apm);
                apn = _service.GetAll().Where(c => c.AuditId == id);
                return Ok(apn);
            }

        }



    }
}
