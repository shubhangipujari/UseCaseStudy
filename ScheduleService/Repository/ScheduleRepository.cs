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
            catch (Exception ex)
            { ex.Message.ToString();
             return null;
            }
        }

        public void CreateSchedule(ScheduleDetail scheduleDetail)
        {
            try
            {
                //scheduleDetail.StartDateTime = scheduleDetail.StartDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                scheduleDetail.StartDateTime = DateTime.ParseExact(scheduleDetail.StartDateTime.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", null);
                scheduleDetail.EndDateTime = DateTime.ParseExact(scheduleDetail.EndDateTime.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", null);

                _dbContext.Add(scheduleDetail);
                Save();
            }
            catch (Exception ex)
            { ex.Message.ToString(); }

        }

        public void UpdateSchedule(ScheduleDetail scheduleDetail)
        {
            try
            {
                _dbContext.Entry(scheduleDetail).State = EntityState.Modified;
                Save();
            }
            catch (Exception ex) { ex.Message.ToString(); }
          
        }

        public void Save()
        {
            try
            {
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
               
            }
        }



        public async Task<IEnumerable<ScheduleDetail>> searchScheduleDetails(string fromPlace, string toPlace, DateTime departuredate,string choosedWay )
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
                if (departuredate != null)
                {
                    query = query.Where(e => e.StartDateTime == departuredate);
                }
                if (choosedWay != null)
                {
                    query = query.Where(e => e.ChooseWay == choosedWay);
                }
                //if (chooseway.emp != '')
                //{
                //    query = query.Where(e => e.ChooseWay == chooseway);
                //}

                return await query.ToListAsync();
            }
            catch (Exception ex)
            { ex.Message.ToString(); return null; }
        }

        public ScheduleDetail GetScheduleById(int scheduleId)
        {
            return _dbContext.details.Find(scheduleId);
        }

    }
}
