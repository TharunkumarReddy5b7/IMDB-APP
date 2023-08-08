using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
using MovieApi.Models.DBModels;
using MovieApi.Models.Requests;
using MovieApi.Services.Interfaces;
using System;

namespace MovieApi.Controllers
{
    [Route("actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        public readonly IActorService _actorService;
        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var actors = _actorService.GetAll();
                return Ok(actors);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var actor = _actorService.GetById(id);
                return Ok(actor);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ActorRequest actor)
        {

            try
            {
                 _actorService.Create(actor);
                return StatusCode(201, $"Actor successfully created");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] ActorRequest actor)
        {
            try
            {
                _actorService.Update(id, actor);
                return Ok("Actor Updated Successfully");
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
                _actorService.Delete(id);
                return Ok("Actor Deleted Succcessfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
