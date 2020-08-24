using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Internal;
using ParkProjectApi.Data;
using ParkProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkProjectApi.IRepository
{
    public class NationalParkRepository: INationalParkRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public NationalParkRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
          
        }

        public bool CreateNationalPark(NationalParks nationalParks)
        {
            _applicationDbContext.NationalParks.Add(nationalParks);
            return Save();
        }

        public bool DeleteNationalPark(NationalParks nationalParks)
        {
            _applicationDbContext.NationalParks.Remove(nationalParks);
            return Save(); 
        }

        public NationalParks GetNationalPark(int nationalParkId)
        {
            return _applicationDbContext.NationalParks.FirstOrDefault(n => n.Id == nationalParkId); 
           
        }

        public ICollection<NationalParks> GetNationalParks()
        {
            return _applicationDbContext.NationalParks.OrderBy(n => n.Name).ToList(); 
        }

        public bool NationalParkExists(string name)
        {
            bool value = _applicationDbContext.NationalParks.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value; 
        }

        public bool NationalParkExists(int id)
        {
            return _applicationDbContext.NationalParks.Any(a => a.Id == id);
           
        }

        public bool Save()
        {
            return _applicationDbContext.SaveChanges() >= 0 ? true : false; 
        }

        public bool updateNationalPark(NationalParks nationalParks)
        {
             _applicationDbContext.NationalParks.Update(nationalParks);
            return Save(); 

        }
    }
}
