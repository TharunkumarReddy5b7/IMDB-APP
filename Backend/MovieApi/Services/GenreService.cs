using AutoMapper;
using MovieApi.Models.DBModels;
using MovieApi.Models.Requests;
using MovieApi.Models.Responses;
using MovieApi.Repositories;
using MovieApi.Repositories.Interfaces;
using MovieApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MovieApi.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        public IList<GenreResponse> GetAll()
        {
            
            var genrelist = _genreRepository.GetAll();
            if (genrelist == null)
            {
                return new List<GenreResponse>();
            }
            return _mapper.Map<List<GenreResponse>>(genrelist);
        }
        public GenreResponse GetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid GenreId");
            }
            var genre = _genreRepository.GetById(id);
            if (genre == null)
            {
                throw new Exception($"Genre with Id {id} not found");
            }
            return _mapper.Map<GenreResponse>(genre);
        }
        public void Create(GenreRequest request)
        {
            ValidateRequest(request);
            var genre = _mapper.Map<GenreModel>(request);
            _genreRepository.Create(genre);
        }
        public void Update(int id, GenreRequest request)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid GenreId");
            }
            var genre = _genreRepository.GetById(id);
            if (genre == null)
            {
                throw new Exception($"Genre with Id {id} not found");
            }
            ValidateRequest(request);

            var updatedGenre = _mapper.Map<GenreModel>(request);
            _genreRepository.Update(id, updatedGenre);
        }
        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid GenreId");
            }
            var genre = _genreRepository.GetById(id);
            if (genre == null)
            {
                throw new Exception($"Genre with Id {id} not found");
            }
            _genreRepository.Delete(id);
        }
        private void ValidateRequest(GenreRequest genre)
        {
            if (string.IsNullOrEmpty(genre.Name))
            {
                throw new Exception("Genre name can not be empty");
            }

        }
    }
}
