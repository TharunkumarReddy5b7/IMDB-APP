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
    [Route("movies/{movieId}/reviews")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult GetAll(int movieId)
        {
            try
            {
                var moviereviews = _reviewService.GetAll(movieId);
                return Ok(moviereviews);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int movieId, int id)
        {
            try
            {
                var review = _reviewService.GetById(movieId, id);
                return Ok(review);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(int movieId, ReviewRequest request)
        {
            try
            {
                _reviewService.Create(movieId, request);
                return StatusCode(201, $"Review  succesfully added to the movie");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id:int}")]

        public IActionResult Update(int movieId, int id, ReviewRequest request)
        {
            try
            {
                _reviewService.Update(movieId, id, request);
                return Ok("Review updated successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int movieId, int id)
        {
            try
            {
                _reviewService.Delete(movieId, id);
                return Ok("Review deleted succcessfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
