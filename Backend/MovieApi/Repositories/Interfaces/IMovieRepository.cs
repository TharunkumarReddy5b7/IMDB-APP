using MovieApi.Models.DBModels;
using System.Collections.Generic;

namespace MovieApi.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        public IList<MovieModel> GetAll();
        public MovieModel GetById(int id);
        public void Create(MovieModel movie,string actorids, string producerids);
        public void Update(int id, MovieModel movie, string actorids, string producerids);
        public void Delete(int id);

        public List<int> GetActorIdsFromMovieActors(int movieid);
        public void DeleteActorIdsFromMovieActors(int movieid);

        public List<int> GetGenreIdsFromMovieGenres(int movieid);
        public void DeleteGenreIdsFromMovieGenres(int movieid);

        public void DeleteReviewsFromMovieReviews(int movieid);
    }
}
