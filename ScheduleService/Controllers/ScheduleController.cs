using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Models;
using ScheduleService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace ScheduleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ISchedule _scheduleRepository;

        public ScheduleController(ISchedule sheduleRepository)
        {
            _scheduleRepository = sheduleRepository;
        }

        [HttpGet]
        [Route("getScheduleDetail")]

        public IActionResult getScheduleDetail()
        {
            try
            {
                var scheduleDetails = _scheduleRepository.GetScheduleDetails();
                return new OkObjectResult(scheduleDetails);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return BadRequest(); 
            }

           
        }

        [HttpPost]
        [Route("createScheduleDetails")]
        public IActionResult CreateSchedule([FromBody] ScheduleDetail scheduleDetail)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _scheduleRepository.CreateSchedule(scheduleDetail);
                    scope.Complete();
                    return CreatedAtAction(nameof(getScheduleDetail), scheduleDetail);
                }
            }
            catch (Exception e)
            { return null; }
          
        }

        [HttpPut]
        [Route("updateScheduleDetails")]
        public IActionResult UpdateSchedule([FromBody] ScheduleDetail scheduleDetail)
        {
            try
            {
                if (scheduleDetail != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        _scheduleRepository.UpdateSchedule(scheduleDetail);
                        scope.Complete();
                        return new OkResult();
                    }
                }
                return new NoContentResult();
            }
            catch(Exception ex) {
                ex.Message.ToString();
                return BadRequest();
            }
          
        }

        [HttpGet]
        [Route("searchScheduleDetails")]

        public async Task<ActionResult<IEnumerable<ScheduleDetail>>> Search(string fromplace, string toPlace)
        {
            try
            {
                var result = await _scheduleRepository.searchScheduleDetails(fromplace, toPlace);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }
        }
    }
}
