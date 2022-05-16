using System;
using System.Collections.Generic;

#nullable disable

namespace TicketBookingService.Models
{
    public partial class FlightBookingDetail
    {
        public int Id { get; set; }
        public int ScheduedId { get; set; }
        public int UserId { get; set; }
        public string MealPreferene { get; set; }
        public decimal Cost { get; set; }
        public string SeatNumber { get; set; }
        public string PnrNumber { get; set; }
        public int IsCanceled { get; set; }
        public DateTime? CreatedModifiedDate { get; set; }
    }
}
