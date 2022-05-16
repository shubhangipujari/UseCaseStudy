using AirLineService.DBContext;
using AirLineService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineService.Repository
{
    public class AirlineRepository : IAirline
    {
        private readonly AirlineContext _dbContext;

        public AirlineRepository(AirlineContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<AirlineDetail> GetAirlines()
        {
            return _dbContext.UserDetails.ToList();
        }

        public void CreateAirline(AirlineDetail airline)
        {
            _dbContext.Add(airline);
            Save();
        }

        public void UpdateAirline(AirlineDetail airline)
        {
            _dbContext.Entry(airline).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

       
    }
}
