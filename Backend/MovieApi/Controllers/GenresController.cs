using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Models.Requests;
using MovieApi.Services;
using MovieApi.Services.Interfaces;
using System;
using System.Numerics;

namespace MovieApi.Controllers
{
    [Route("genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {

            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {

                var genre = _genreService.GetAll();
                return Ok(genre);
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
                var genre = _genreService.GetById(id);
                return Ok(genre);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Create([FromBody] GenreRequest request)
        {
            try
            {
                _genreService.Create(request);
                return StatusCode(201, $"Genre successfully created");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] GenreRequest request)
        {
            try
            {
                _genreService.Update(id, request);
                return Ok($"Genre Updated Successfully");
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
                _genreService.Delete(id);
                return Ok($"Genre Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
