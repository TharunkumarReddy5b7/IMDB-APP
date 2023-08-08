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
using System.Data;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace MovieApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly IActorService _actorService;
        private readonly IGenreService _genreService;
        private readonly IProducerService _producerService;
        
        public MovieService(IMovieRepository movieRepository, IMapper mapper, IActorService actorService, IGenreService genreservice, IProducerService producerService)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _actorService = actorService;
            _genreService = genreservice;   
            _producerService = producerService;         
            
        }
        public IList<MovieResponse> GetAll()
        {
            var movies = _movieRepository.GetAll();
            if (movies == null)
            {
                return new List<MovieResponse>();
            }
            List<MovieResponse> movieResponsesList = new List<MovieResponse>();
            movies.ToList().ForEach(movie =>
            {
                var movieResponse = new MovieResponse();
                {
                    movieResponse.Id = movie.Id;
                    movieResponse.Name = movie.Name;
                    movieResponse.YearOfRelease = movie.YearOfRelease;
                    movieResponse.Plot = movie.Plot;
                    movieResponse.Producer = _producerService.GetById(movie.ProducerId);
                    movieResponse.CoverImage = movie.CoverImage;
                }

                List<int> actorIds = _movieRepository.GetActorIdsFromMovieActors(movie.Id);
                List<int> genreIds = _movieRepository.GetGenreIdsFromMovieGenres(movie.Id);
                movieResponse.Actors = actorIds.Select(actorid => _actorService.GetById(actorid)).ToList();
                movieResponse.Genres = genreIds.Select(genreid => _genreService.GetById(genreid)).ToList();
                movieResponsesList.Add(movieResponse);
            });
            return movieResponsesList;
        }
        public MovieResponse GetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid MovieId");
            }
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                throw new Exception($"Movie with Id {id} not found");
            }

            MovieResponse movieResponse = new MovieResponse();
            {
                movieResponse.Id = movie.Id;
                movieResponse.Name = movie.Name;
                movieResponse.YearOfRelease = movie.YearOfRelease;
                movieResponse.Plot = movie.Plot;
                movieResponse.Producer = _producerService.GetById(movie.ProducerId);
                movieResponse.CoverImage = movie.CoverImage;
            }
            List<int> actorIds = _movieRepository.GetActorIdsFromMovieActors(movie.Id);
            List<int> genreIds = _movieRepository.GetGenreIdsFromMovieGenres(movie.Id);
            movieResponse.Actors = actorIds.Select(actorid => _actorService.GetById(actorid)).ToList();
            movieResponse.Genres = genreIds.Select(genreid => _genreService.GetById(genreid)).ToList();
            return movieResponse;
        }
        public void Create(MovieRequest request)
        {
            ValidateRequest(request);
            var movie = new MovieModel
            {
                Name = request.Name,
                Plot = request.Plot,
                YearOfRelease = request.YearOfRelease,
                ProducerId = request.ProducerId,
                CoverImage = request.CoverImage
            };
            var actorids = string.Join(",", request.Actorids);
            var genreids = string.Join(",", request.Genreids);
            _movieRepository.Create(movie,actorids, genreids);
        }

        public void Update(int id, MovieRequest request)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid MovieId");
            }
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                throw new Exception($"Movie with Id {id} not found");
            }
            ValidateRequest(request);

            var updatedMovie = new MovieModel
            {
                Name = request.Name,
                Plot = request.Plot,
                YearOfRelease = request.YearOfRelease,
                ProducerId = request.ProducerId,
                CoverImage = request.CoverImage
            };
            var actorids = string.Join(",", request.Actorids);
            var genreids = string.Join(",", request.Genreids);

            _movieRepository.Update(id, updatedMovie, actorids, genreids);

        }
        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid MovieId");
            }
            if (_movieRepository.GetById(id) == null)
            {
                throw new Exception($"Movie with Id {id} not found");
            }
            _movieRepository.DeleteActorIdsFromMovieActors(id);
            _movieRepository.DeleteGenreIdsFromMovieGenres(id);
            _movieRepository.DeleteReviewsFromMovieReviews(id);
            _movieRepository.Delete(id);
        }
        public void ValidateRequest(MovieRequest movie)
        {
            if (string.IsNullOrEmpty(movie.Name)) { throw new Exception("Movie name can not be null or empty"); }
            if (string.IsNullOrEmpty(movie.Plot)) { throw new Exception("Plot can not be empty"); }

            if (movie.YearOfRelease <= 0) { throw new Exception("Enter valid year"); }

            if (string.IsNullOrEmpty(movie.CoverImage)) { throw new Exception(("cover image cannot be empty")); }

            if (movie.Actorids.Count <= 0 || movie.Actorids == null) { throw new Exception("please enter atleast one actorid"); }

            if (movie.Genreids.Count <= 0 || movie.Genreids == null) { throw new Exception("please enter atleast one Genreid"); }

            if (_producerService.GetById(movie.ProducerId) == null) { throw new Exception($"Producer with producerid {movie.ProducerId} not found"); }

            movie.Actorids.ForEach(id =>
            {
                if (_actorService.GetById(id) == null) { throw new Exception($"Actor with Id {id} not found"); }
            });

            movie.Genreids.ForEach(id =>
            {
                if (_genreService.GetById(id) == null) { throw new Exception($"Genre with Id {id} not found"); }
            });
        }
    }
}
