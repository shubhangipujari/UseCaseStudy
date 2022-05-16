using System;
using System.Collections.Generic;

#nullable disable

namespace AdminService.Models1
{
    public partial class ScheduleDetail
    {
        public int Id { get; set; }
        public int AirlineId { get; set; }
        public string FlightNumber { get; set; }
        public string FlightName { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string ScheduledDays { get; set; }
        public string InstrumentUsed { get; set; }
        public int TotNumBuisSeat { get; set; }
        public int TotNumNonbuisSeat { get; set; }
        public decimal TicketCost { get; set; }
        public int NumberOfRows { get; set; }
        public string Meal { get; set; }
        public string ChooseWay { get; set; }
    }
}
