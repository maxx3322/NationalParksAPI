using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ParkProjectApi.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkProjectApi.Models.Dtos;
using ParkProjectApi.Models;

namespace ParkProjectApi.AutoMapper
{
    public class ParkMappings: Profile
    {
        public ParkMappings()
        {
            CreateMap<NationalParks,NationalParksDto>().ReverseMap(); 
        }
    }
}
