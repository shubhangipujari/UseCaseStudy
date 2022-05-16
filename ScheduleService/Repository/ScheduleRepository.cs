using Microsoft.EntityFrameworkCore;
using ScheduleService.Context;
using ScheduleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleService.Repository
{
    public class ScheduleRepository:ISchedule
    {
        private readonly ScheduleContext _dbContext;

        public ScheduleRepository(ScheduleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<ScheduleDetail> GetScheduleDetails()
        {
            try {
                return _dbContext.details.ToList();

            }
            catch (Exception e)
            { return null; }
        }

        public void CreateSchedule(ScheduleDetail scheduleDetail)
        {
            try
            {
                _dbContext.Add(scheduleDetail);
                Save();
            }
            catch (Exception e)
            { }

        }

        public void UpdateSchedule(ScheduleDetail scheduleDetail)
        {
            try
            {
                _dbContext.Entry(scheduleDetail).State = EntityState.Modified;
                Save();
            }
            catch (Exception e) { }
          
        }

        public void Save()
        {
            try
            {
                _dbContext.SaveChanges();

            }
            catch (Exception e)
            {

            }
        }



        public async Task<IEnumerable<ScheduleDetail>> searchScheduleDetails(string fromPlace, string toPlace)
        {
            try
            {
                IQueryable<ScheduleDetail> query = _dbContext.details;



                if (fromPlace != null)
                {
                    query = query.Where(e => e.FromPlace == fromPlace);
                }
                if (toPlace != null)
                {
                    query = query.Where(e => e.ToPlace == toPlace);
                }
                //if (chooseway.emp != '')
                //{
                //    query = query.Where(e => e.ChooseWay == chooseway);
                //}

                return await query.ToListAsync();
            }
            catch (Exception e)
            { return null; }
        }
    }
}
