using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ParkProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkProjectApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<NationalParks> NationalParks { get; set; }
        public DbSet<Trail>Trail { get; set; }
    }
}
