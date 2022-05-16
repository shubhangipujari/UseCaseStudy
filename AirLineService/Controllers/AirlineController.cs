using AirLineService.Models;
using AirLineService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace AirLineService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private readonly IAirline _airlineRepository;

        public AirlineController(IAirline airlineRepository)
        {
            _airlineRepository = airlineRepository;
        }

        [HttpGet]
        [Route("getAirlines")]

        public IActionResult getAirlines()
        {
            try
            {
                var users = _airlineRepository.GetAirlines();
                return new OkObjectResult(users);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }
            
        }


        [HttpPost]
        [Route("createAirline")]


        public IActionResult CreateAirline([FromBody] AirlineDetail airline)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _airlineRepository.CreateAirline(airline);
                    scope.Complete();
                    return CreatedAtAction(nameof(getAirlines), airline);
                }
            }
            catch(Exception ex) {
                ex.Message.ToString();
                return BadRequest();
            }
          
        }

        [HttpPut]
        [Route("updateAirline")]
        public IActionResult UpdateAirline([FromBody] AirlineDetail airline)
        {
            try
            {
                if (airline != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        _airlineRepository.UpdateAirline(airline);
                        scope.Complete();
                        return new OkResult();
                    }
                }
                return new NoContentResult();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }
        }
    }
}
