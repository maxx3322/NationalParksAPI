using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static ParkProjectApi.Models.Trail;

namespace ParkProjectApi.Models.Dtos
{
    public class TrailDto
    {

           [Key]
            public int Id { get; set; }

            [Required]

            public string Name { get; set; }

            [Required]
            public double Distance { get; set; }


            public DifficultyType Difficulty { get; set; }


            [Required]
            public int NationalParkId { get; set; }

            
            public NationalParks NationalPark { get; set; }

        }
    }
