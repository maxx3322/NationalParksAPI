using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkProjectApi.IRepository;
using ParkProjectApi.Models;
using ParkProjectApi.Models.Dtos;

namespace ParkProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalParksController : Controller
    {
        private INationalParkRepository _nationalParkRepository;
        private readonly IMapper _imapper;

        public NationalParksController(INationalParkRepository nationalParkRepository, IMapper imapper)
        {
            _nationalParkRepository = nationalParkRepository;
            _imapper = imapper; 

        }

       [HttpGet]
       public IActionResult GetNationalParks()
        {
            var parkList = _nationalParkRepository.GetNationalParks();

            var parkListDto = new List<NationalParksDto>();

            foreach(var park in parkList)
            {
                parkListDto.Add(_imapper.Map<NationalParksDto>(park)); 
                    
               
            }
            return Ok(parkListDto);  
        }

        [HttpGet("{nationalParkId:int}")]
        public IActionResult GetNationalPark(int nationalParkId)
        { 
            
        
            var park = _nationalParkRepository.GetNationalPark(nationalParkId);
            if (park == null)
            {
                return NotFound();
            }

            var parkDto = _imapper.Map<NationalParksDto>(park);

            return Ok(parkDto); 
        }
    }
}
