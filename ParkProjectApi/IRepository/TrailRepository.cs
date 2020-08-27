using Microsoft.EntityFrameworkCore.Diagnostics;
using ParkProjectApi.Data;
using ParkProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkProjectApi.IRepository
{
    public class TrailRepository : ITrailRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public TrailRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }

        public bool CreateTrail(Trail trail)
        {
            _applicationDbContext.Trail.Add(trail);
            return Save();
        }

        public bool DeleteTrail(Trail trail)
        {
            _applicationDbContext.Trail.Remove(trail);
            return Save();
        }

        public ICollection<Trail> GetTrails()
        {
            return _applicationDbContext.Trail.OrderBy(t => t.Name).ToList();
        }

        public Trail GetTrail(int trailId)
        {
            return _applicationDbContext.Trail.FirstOrDefault(t => t.Id == trailId);
        }

        //How do I seperate this to make it reuseable
        public bool Save()
        {
            return _applicationDbContext.SaveChanges() >= 0 ? true : false;
        }

        public bool TrailExists(string name)
        {
            bool value = _applicationDbContext.Trail.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool TrailExists(int id)
        {
            return _applicationDbContext.Trail.Any(a => a.Id == id);

        }

        public bool UpdateTrail(Trail trail)
        {
            _applicationDbContext.Trail.Update(trail);
            return Save();

        }

    }
}
