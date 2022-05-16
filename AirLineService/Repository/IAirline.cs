using AirLineService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineService.Repository
{
   public interface IAirline
    {
        IEnumerable<AirlineDetail> GetAirlines();

        void CreateAirline(AirlineDetail airline);
       // void DeleteUser(int userId);
        void UpdateAirline(AirlineDetail airline);

        void Save();
    }
}
