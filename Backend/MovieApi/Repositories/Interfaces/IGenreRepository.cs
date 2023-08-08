using MovieApi.Models.DBModels;
using System.Collections.Generic;

namespace MovieApi.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        public IList<GenreModel> GetAll();
        public GenreModel GetById(int id);
        public void Create(GenreModel genre);
        public void Update(int id, GenreModel genre);
        public void Delete(int id);  
        
    }
}
