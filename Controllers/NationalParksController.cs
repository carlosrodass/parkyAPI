using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyApi.Models;
using ParkyApi.Models.Dtos;
using ParkyApi.Repository;

namespace ParkyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalParksController : ControllerBase
    {

        private readonly INationalParkRepository _INationalParkRepository;
        private readonly IMapper _IMapper;

        public NationalParksController(INationalParkRepository nationalParkRepository, IMapper mapper)
        {
            _INationalParkRepository = nationalParkRepository;
            _IMapper = mapper;
        }


        [HttpGet]
        public IActionResult GetNationalPark()
        {
            var result = _INationalParkRepository.GetNationalParks();

            try
            {
                return Ok(_IMapper.Map<IEnumerable<NationalParkDto>>(result));
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet("{id:int}", Name = "GetNationalParkById")]
        public IActionResult GetNationalParkById(int id)
        {
            var result = _INationalParkRepository.GetNationalPark(id);

            try
            {
                return Ok(_IMapper.Map<NationalParkDto>(result));
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        public IActionResult CreateNationalPark(NationalParkDto nationalParkDto)
        {
            if (nationalParkDto == null) return BadRequest(ModelState);

            if (_INationalParkRepository.NationalParkExist(nationalParkDto.Name))
            {
                ModelState.AddModelError("", "National Park Already existe");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var obj = _IMapper.Map<NationalPark>(nationalParkDto);

            if (!_INationalParkRepository.CreateNationalPark(obj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {obj.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetNationalParkById", new { id = obj.Id }, obj);
        }

        [HttpPut("{id:int}", Name = "UpdateNationalPark")]
        public IActionResult UpdateNationalPark(int id, NationalParkDto nationalParkDto)
        {
            if (nationalParkDto == null || id != nationalParkDto.Id) return BadRequest(ModelState);

            try
            {
                var obj = _IMapper.Map<NationalPark>(nationalParkDto);

                if (!_INationalParkRepository.UpdateNationalPark(obj))
                {
                    ModelState.AddModelError("", $"Something went wrong when updating the record {obj.Name}");
                    return StatusCode(500, ModelState);
                }
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteNationalPark(int id)
        {
            if (!_INationalParkRepository.NationalParkExists(id))
            {
                return NotFound();
            }

            var obj = _INationalParkRepository.GetNationalPark(id);

            if (!_INationalParkRepository.DeleteNationalPark(obj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {obj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();





        }



    }
}
