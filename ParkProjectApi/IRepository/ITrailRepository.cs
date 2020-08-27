using ParkProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkProjectApi.IRepository
{
    public interface ITrailRepository
    {
        ICollection<Trail> GetTrails();
        Trail GetTrail(int trailId);
        bool DeleteTrail(Trail trails);
        bool TrailExists(string name);
        bool TrailExists(int id);
        public bool Save();
        bool CreateTrail(Trail trail);
        bool UpdateTrail(Trail trail);


    }
}
