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
    public class ActionPointNatureController : ControllerBase
    {
        EQMActionPointNatureReporitory EQMActionPointNatureReporitory { get; set; }

        private readonly ILogger<EqmActionPointNature> _logger;
        private readonly EQMDbContext _EQMDbContext;
       public ActionPointNatureController(ILogger<EqmActionPointNature> logger, EQMDbContext EQMDbContext)
        {
            _logger = logger;
            _EQMDbContext = EQMDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        { 
                EQMActionPointNatureReporitory = new EQMActionPointNatureReporitory(_logger, _EQMDbContext);
                ServiceActionPointNature _service = new ServiceActionPointNature(EQMActionPointNatureReporitory);
                return Ok(_service.GetAll());
              
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        { 
                EQMActionPointNatureReporitory = new EQMActionPointNatureReporitory(_logger, _EQMDbContext);
                ServiceActionPointNature _service = new ServiceActionPointNature(EQMActionPointNatureReporitory);
                EqmActionPointNature? Apm = _service.GetAll().Where(c => c.NatureId == id).FirstOrDefault();
                if(Apm != null)
                {
                    return Ok(Apm);  }
                else { 
                    return NotFound(); } 
       
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        { 
                EQMActionPointNatureReporitory = new EQMActionPointNatureReporitory(_logger, _EQMDbContext);
                ServiceActionPointNature _service = new ServiceActionPointNature(EQMActionPointNatureReporitory);
                  _service.Delete(id);
               return Ok();
        
        }
         
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ActionPointNature apm)
        {
            if (apm is null)
            {
                return BadRequest(string.Format(Const_Msg.CONST_REQUEST_CONTENT_NULL, Const_Msg.CONST_CLASS_NAME_APN));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(string.Format(Const_Msg.CONST_REQUEST_CONTENT_INVALID, Const_Msg.CONST_CLASS_NAME_APN));
            }

           
                EQMActionPointNatureReporitory = new EQMActionPointNatureReporitory(_logger, _EQMDbContext);
                ServiceActionPointNature _service = new ServiceActionPointNature(EQMActionPointNatureReporitory);
                var _apm = await _service.Add(apm);
                return Created("ActionPointNature", _apm);   
         
             
        }

        [HttpPut]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActionPointNature apm)
        {
            if (apm == null)
            {
                return BadRequest( string.Format( Const_Msg.CONST_REQUEST_CONTENT_NULL, Const_Msg.CONST_CLASS_NAME_APN ));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(string.Format(Const_Msg.CONST_REQUEST_CONTENT_INVALID, Const_Msg.CONST_CLASS_NAME_APN));
            }
             
                EQMActionPointNatureReporitory = new EQMActionPointNatureReporitory(_logger, _EQMDbContext);
                ServiceActionPointNature _service = new ServiceActionPointNature(EQMActionPointNatureReporitory);
                var apn = _service.GetAll().Where(c=>c.NatureId== id);
                if (apn == null)
                {
                    return NotFound();
                } 
                _service.Update(id, apm);
                apn = _service.GetAll().Where(c => c.NatureId == id);
                return Ok(apn);
           
             
        }




    }
}
