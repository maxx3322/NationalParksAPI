using ParkProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkProjectApi.IRepository
{
    public interface INationalParkRepository
    {
        ICollection<NationalParks> GetNationalParks();
        NationalParks GetNationalPark(int nationalParkId);
        bool DeleteNationalPark(NationalParks nationalParks);
        bool NationalParkExists(string name);
        bool NationalParkExists(int id);
        public bool Save(); 
        bool CreateNationalPark(NationalParks nationalParks);
        bool UpdateNationalPark(NationalParks nationalParks); 
    }
}
