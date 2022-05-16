using System;
using System.Collections.Generic;

#nullable disable

namespace AdminService.Models1
{
    public partial class AirlineDetail
    {
        public int Id { get; set; }
        public string AirlineName { get; set; }
        public string Logo { get; set; }
        public string ContactNumber { get; set; }
        public string ContactAddress { get; set; }
        public int IsBlocked { get; set; }
    }
}
