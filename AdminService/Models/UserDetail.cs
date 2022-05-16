using System;
using System.Collections.Generic;

#nullable disable

namespace AdminService.Models
{
    public partial class UserDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public string RoleName { get; set; }
        public int Age { get; set; }
        public int IsActive { get; set; }
        public string Password { get; set; }

       

    }
}
