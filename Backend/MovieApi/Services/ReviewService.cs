using AutoMapper;
using MovieApi.Helpers;
using MovieApi.Models.DBModels;
using MovieApi.Models.Requests;
using MovieApi.Models.Responses;
using MovieApi.Repositories;
using MovieApi.Repositories.Interfaces;
using MovieApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Numerics;

namespace MovieApi.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        public ReviewService(IReviewRepository revieWRepository, IMapper mapper, IMovieRepository movieRepository)
        {
            _reviewRepository = revieWRepository;
            _mapper = mapper;
            _movieRepository = movieRepository;
        }
        public IList<ReviewResponse> GetAll(int movieid)
        {

            if (_movieRepository.GetById(movieid)==null)
            {
                throw new Exception($"Movie with id {movieid} not present to get reviews");
            }
            var moviereviews = _reviewRepository.GetAll(movieid);
            if (moviereviews == null)
            {
                return null;
            }
            return _mapper.Map<IList<ReviewResponse>>(moviereviews);
        }

        public ReviewResponse GetById(int movieid, int id)
        {
            if (_movieRepository.GetById(movieid) == null)
            {
                throw new Exception($"Movie with id {movieid} not present to get review");
            }
            var review = _reviewRepository.GetById(movieid, id);
            if (review == null) { return null; }

            return _mapper.Map<ReviewResponse>(review);
        }

        public void Create(int movieid, ReviewRequest request)
        {
            if (_movieRepository.GetById(movieid) == null)
            {
                throw new Exception($"Movie with id {movieid} not present to give review");
            }
            ValidateRequest(request);
            var review = _mapper.Map<ReviewModel>(request);
            
            _reviewRepository.Create(movieid,review);
           
        }
        public void Update(int movieid, int id, ReviewRequest request)
        {
            if (_movieRepository.GetById(movieid) == null)
            {
                throw new Exception($"Movie with id {movieid} not present to give review");
            }
            var review = _reviewRepository.GetById(movieid, id);
            if (review == null)
            {
                throw new Exception($"Review with id {id} not present for the movie");

            }
            ValidateRequest(request);
            var updatedReview = _mapper.Map<ReviewModel>(request);
            _reviewRepository.Update(movieid, id, updatedReview);
        }
        public void Delete(int movieid, int id)
        {
            if (_movieRepository.GetById(movieid) == null)
            {
                throw new Exception($"Movie with id {movieid} not present to delete review");
            }
            if (_reviewRepository.GetById(movieid, id) == null)
            {
                throw new Exception($" Movie with movieid{movieid} and review  id {id} not present to delete");
            }
            _reviewRepository.Delete(movieid, id);
        }
        private void ValidateRequest(ReviewRequest review)
        {
            if (string.IsNullOrEmpty(review.Message))
            {
                throw new Exception("Review Message can not be empty");
            }

        }
    }
}
