using ScheduleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleService.Repository
{
    public interface ISchedule
    {
        IEnumerable<ScheduleDetail> GetScheduleDetails();

        void CreateSchedule(ScheduleDetail scheduleDetail);
        // void DeleteUser(int userId);
        void UpdateSchedule(ScheduleDetail scheduleDetail);
       Task<IEnumerable<ScheduleDetail>> searchScheduleDetails( string fromPlace, string toPlace,DateTime depaturedate,string chooedWay);

        ScheduleDetail GetScheduleById(int scheduleId);

        //Task<IEnumerable<ScheduleDetail>> searchScheduleDetails(DateTime StartDateTime, DateTime endDateTime, string fromPlace, string toPlace, char chooseway);

        void Save();
    }
}
