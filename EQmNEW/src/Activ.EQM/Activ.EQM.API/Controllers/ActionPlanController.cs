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
    public class ActionPlanController : ControllerBase
    {
        EQMActionPlanReporitory EQMActionPlanReporitory { get; set; }

        private readonly ILogger<EqmActionPlan> _logger;
        private readonly EQMDbContext _EQMDbContext;

        public ActionPlanController(ILogger<EqmActionPlan> logger, EQMDbContext EQMDbContext)
        {
            _logger = logger;
            _EQMDbContext = EQMDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        { 
            {
                EQMActionPlanReporitory = new EQMActionPlanReporitory(_logger, _EQMDbContext);
                ServiceActionPlan _service = new ServiceActionPlan(EQMActionPlanReporitory);
                return Ok(_service.GetAll());
            } 
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
             
            {
                EQMActionPlanReporitory = new EQMActionPlanReporitory(_logger, _EQMDbContext);
                ServiceActionPlan _service = new ServiceActionPlan(EQMActionPlanReporitory);
                EqmActionPlan? Apm = _service.GetAll().Where(c => c.ActionPlanId == id).FirstOrDefault();
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
                EQMActionPlanReporitory = new EQMActionPlanReporitory(_logger, _EQMDbContext);
                ServiceActionPlan _service = new ServiceActionPlan(EQMActionPlanReporitory);
                  _service.Delete(id);
               return Ok();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ActionPlan apm)
        {
            if (apm is null)
            {
                return BadRequest(string.Format(Const_Msg.CONST_REQUEST_CONTENT_NULL, Const_Msg.CONST_CLASS_NAME_APN));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(string.Format(Const_Msg.CONST_REQUEST_CONTENT_INVALID, Const_Msg.CONST_CLASS_NAME_AP));
            }

            
            {
                EQMActionPlanReporitory = new EQMActionPlanReporitory(_logger, _EQMDbContext);
                ServiceActionPlan _service = new ServiceActionPlan(EQMActionPlanReporitory);
                var _apm = await _service.Add(apm);
                return Created("ActionPlan", _apm);   
            }
             
        }


        [HttpPut]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActionPlan apm)
        {
            if (apm == null)
            {
                return BadRequest(string.Format(Const_Msg.CONST_REQUEST_CONTENT_NULL, Const_Msg.CONST_CLASS_NAME_APN));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(string.Format(Const_Msg.CONST_REQUEST_CONTENT_INVALID, Const_Msg.CONST_CLASS_NAME_APN));
            }

           
                EQMActionPlanReporitory = new EQMActionPlanReporitory(_logger, _EQMDbContext);
                ServiceActionPlan _service = new ServiceActionPlan(EQMActionPlanReporitory);
                var apn = _service.GetAll().Where(c => c.ActionPlanId == id);
                if (apn == null)
                {
                    return NotFound();
                }
                _service.Update(id, apm);
                apn = _service.GetAll().Where(c => c.ActionPlanId == id);
                return Ok(apn);
           

        }



    }
}
