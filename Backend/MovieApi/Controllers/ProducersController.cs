using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Models.Requests;
using MovieApi.Services;
using MovieApi.Services.Interfaces;
using System;
using System.Numerics;

namespace MovieApi.Controllers
{

    [ApiController]
    [Route("producers")]
    public class ProducersController : ControllerBase
    {
        private readonly IProducerService _producerService;
        public ProducersController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var producers = _producerService.GetAll();
                return Ok(producers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var producer = _producerService.GetById(id);
                return Ok(producer);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Create([FromBody] ProducerRequest producer)
        {
            try
            {
                _producerService.Create(producer);
                return StatusCode(201, $"Producer successfully created");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] ProducerRequest producer)
        {
            try
            {
                _producerService.Update(id, producer);
                return Ok("Producer updated successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _producerService.Delete(id);
                return Ok("Producer Deleted Succcessfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
