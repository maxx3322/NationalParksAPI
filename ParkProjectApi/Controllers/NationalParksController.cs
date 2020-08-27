using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ParkProjectApi.IRepository;
using ParkProjectApi.Models;
using ParkProjectApi.Models.Dtos;

namespace ParkProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalParksController : Controller
    {
        private readonly INationalParkRepository _nationalParkRepository;
        private readonly IMapper _imapper;

        public NationalParksController(INationalParkRepository nationalParkRepository, IMapper imapper)
        {
            _nationalParkRepository = nationalParkRepository;
            _imapper = imapper;

        }

        [HttpGet]
        [ProducesResponseType(200, Type=typeof(List<NationalParksDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetNationalParks()
        {
            var parkList = _nationalParkRepository.GetNationalParks();

            var parkListDto = new List<NationalParksDto>();

            foreach (var park in parkList)
            {
                parkListDto.Add(_imapper.Map<NationalParksDto>(park));


            }
            return Ok(parkListDto);
        }

        [HttpGet("{nationalParkId:int}", Name = "GetNationalPark")]
        [ProducesResponseType(200, Type = typeof(NationalParksDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetNationalPark(int nationalParkId)
        {


            var park = _nationalParkRepository.GetNationalPark(nationalParkId);
            if (park == null)
            {
                return NotFound();
            }

            //   var parkDto = _imapper.Map<NationalParksDto>(park);

            var parkDto = new NationalParksDto()
            {
                Created = park.Created,
                Id = park.Id,
                Name = park.Name,
                State = park.State
            };

            return Ok(parkDto);
        }


        [HttpPost]
        [ProducesResponseType(201, Type = typeof(NationalParksDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]


        public IActionResult CreateNationalPark([FromBody] NationalParksDto nationalParksDto)
        {
            if (nationalParksDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_nationalParkRepository.NationalParkExists(nationalParksDto.Name))
            {
                ModelState.AddModelError("", "Natinal Park already exisists!");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nationalParkObj = _imapper.Map<NationalParks>(nationalParksDto);
            if (!_nationalParkRepository.CreateNationalPark(nationalParkObj))
            {
                ModelState.AddModelError("", $"Something went wrong while saving the record{nationalParkObj.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetNationalPark", new { nationalParkId = nationalParkObj.Id });

        }
        [HttpPatch("{nationalParkId:int}", Name = "UpdateNationalPark")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateNationalPark(int nationalParkId, [FromBody]
        NationalParksDto nationalParksDto)
        {
            if (nationalParksDto == null || nationalParkId != nationalParksDto.Id)
            {
                return BadRequest(ModelState);
            }
            var nationalParkObj = _imapper.Map<NationalParks>(nationalParksDto);
            if (!_nationalParkRepository.UpdateNationalPark(nationalParkObj))
            {
                ModelState.AddModelError("", $"Something went wrong while updating the record{nationalParkObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
        [HttpDelete("{nationalParkId:int}", Name = "DeleteNationalPark")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        
        public IActionResult DeleteNationalPark(int nationalParkId)
        {
            if (!_nationalParkRepository.NationalParkExists(nationalParkId))
            {
                return NotFound();
            }
            var nationalParkObj = _nationalParkRepository.GetNationalPark(nationalParkId);
            if (!_nationalParkRepository.DeleteNationalPark(nationalParkObj))
            {
                ModelState.AddModelError("", $"Something went wrong while deleting the record{nationalParkObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }

}








