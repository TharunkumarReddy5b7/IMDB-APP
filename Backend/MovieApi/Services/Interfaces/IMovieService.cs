using MovieApi.Models.Requests;
using MovieApi.Models.Responses;
using System.Collections.Generic;

namespace MovieApi.Services.Interfaces
{
    public interface IMovieService
    {
        public IList<MovieResponse> GetAll();
        public MovieResponse GetById(int id);
        public void Create(MovieRequest movie);
        public void Update(int id, MovieRequest movie);
        public void Delete(int id);
    }
}
