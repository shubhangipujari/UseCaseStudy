using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using TicketBookingService.Models;
using TicketBookingService.Repository;

namespace TicketBookingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketBookingController : ControllerBase
    {
        private readonly ITicketBooking _TicketRepository;

        public TicketBookingController(ITicketBooking TicketRepository)
        {
            _TicketRepository = TicketRepository;
        }

        [HttpGet]
        [Route("getTicketBooking")]

        public IActionResult getTicketBooking()
        {
            try
            {
                var ticketBookingDetails = _TicketRepository.GetTicketBooking();
                return new OkObjectResult(ticketBookingDetails);
            }
            catch (Exception ex)
            { 
                 ex.Message.ToString();
                return BadRequest();
            }
           
        }


        [HttpPost]
        [Route("createTicketBooking")]
        public IActionResult CreateTicketBooing([FromBody] FlightBookingDetail ticketBookingDetails)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    Random r = new Random();
                    int pnrNumber = r.Next();
                    ticketBookingDetails.PnrNumber = pnrNumber.ToString();
                    _TicketRepository.CreateTicketBooking(ticketBookingDetails);
                    scope.Complete();
                    return CreatedAtAction(nameof(getTicketBooking), ticketBookingDetails.PnrNumber);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }
         
        }
        //cancle Ticket using IS_CANCELED=1
        [HttpPut]
        [Route("updateScheduleDetails")]
        public IActionResult UpdateTicketBooking([FromBody] FlightBookingDetail scheduleDetail)
        {
            try
            {
                if (scheduleDetail != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        _TicketRepository.UpdateTicketBooking(scheduleDetail);
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


        [HttpGet]
        [Route("getFlightById")]
        public IActionResult GetFlightById(int id)
        {
            try
            {
                var flightDetails = _TicketRepository.GetFlightById(id);
                return new OkObjectResult(flightDetails);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("getPnrDetails")]
        public  IActionResult GetPnrDetails(string pnrNumber)
        {
            try
            {

               // var flightDetails=
                var flightDetails = _TicketRepository.GetPnrDetails(pnrNumber);
                return new OkObjectResult(flightDetails);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("getEmailDetails")]
        public IActionResult GetEmailDetails(string email)
        {
            try
            {
                var flightDetails = _TicketRepository.History(email);
                return new OkObjectResult(flightDetails);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }
        }
    }
}