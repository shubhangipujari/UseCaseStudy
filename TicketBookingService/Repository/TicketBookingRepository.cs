using AdminService.DBContext;
using AdminService.Models;
using AdminService.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingService.Context;
using TicketBookingService.Models;

namespace TicketBookingService.Repository
{
    public class TicketBookingRepository : ITicketBooking
    {
        private readonly TicketBookingContext _dbContext;
       


        public TicketBookingRepository(TicketBookingContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateTicketBooking(FlightBookingDetail ticketBookinh)
        {
               _dbContext.Add(ticketBookinh);
                Save();              
        }
        public IEnumerable<FlightBookingDetail> GetTicketBooking()
        {
           return _dbContext.details.ToList();
        }
        public void Save()
        {
         _dbContext.SaveChanges();
        }
        public void UpdateTicketBooking(FlightBookingDetail ticketBookinh)
        {
            try
            {
                _dbContext.Entry(ticketBookinh).State = EntityState.Modified;
                Save();
            }
            catch (Exception ex)
            { ex.Message.ToString(); }
         
        }

        public FlightBookingDetail GetFlightById(int flightId)
        {
            return _dbContext.details.Find(flightId);
        }
        public IEnumerable<FlightBookingDetail> GetPnrDetails(string pnrNumber)
        {
            List<FlightBookingDetail> res = new List<FlightBookingDetail>();
             res = _dbContext.details.Where(x => x.PnrNumber == pnrNumber).ToList<FlightBookingDetail>();
           return res;
           
        }
        public IEnumerable<FlightBookingDetail> History(string email)
        {
             UserContext _dbUserContext=new UserContext();
        List<UserDetail> res = new List<UserDetail>();
            List<FlightBookingDetail> resDetails = new List<FlightBookingDetail>();

            res = _dbUserContext.UserDetails.Where(x => x.Email == email).ToList<UserDetail>();
            int userid= res[0].Id;
            resDetails = _dbContext.details.Where(x => x.UserId == userid).ToList<FlightBookingDetail>();

            return resDetails;           
        }
    }
}
