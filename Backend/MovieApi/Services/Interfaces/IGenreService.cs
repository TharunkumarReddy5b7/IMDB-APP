using MovieApi.Models.Requests;
using MovieApi.Models.Responses;
using System.Collections.Generic;

namespace MovieApi.Services.Interfaces
{
    public interface IGenreService
    {
        public IList<GenreResponse> GetAll();
        public GenreResponse GetById(int id);
        public void Create(GenreRequest genre);
        public void Update(int id, GenreRequest genre);
        public void Delete(int id);
    }
}
