using Azure.Core;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MovieApi.Helpers;
using MovieApi.Models.DBModels;
using MovieApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MovieApi.Repositories
{
    public class MovieRepository :BaseRepository<MovieModel>, IMovieRepository
    {
        private readonly string _connectionString;
        public MovieRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDBDB)
        {
            _connectionString = connectionString.Value.IMDBDB;
        }
        public IList<MovieModel> GetAll()
        {
            const string query = @"
                                SELECT Id
	                                ,Name
	                                ,Plot
	                                ,YearOfRelease
	                                ,ProducerId
	                                ,[Poster] AS CoverImage
                                FROM Foundation.movies";
            return GetAll(query).ToList();
        }
        public MovieModel GetById(int id)
        {
            const string query = @"
                                SELECT Id
	                                ,Name
	                                ,Plot
	                                ,YearOfRelease
	                                ,ProducerId
	                                ,[Poster] AS CoverImage
                                FROM Foundation.movies
                                WHERE Id = @Id";
            return GetById(query, new { id });
        }
        public void Create(MovieModel movie, string actorids, string genreids)
        {
            var query = "Foundation.spInsertMovie";
            var values = new { Name = movie.Name, Plot = movie.Plot, Year = movie.YearOfRelease, ProducerId = movie.ProducerId, Poster = movie.CoverImage, ActorIDs = actorids, GenreIDs = genreids };
            using var connection = new SqlConnection(_connectionString);
            connection.Query(query, values, commandType: CommandType.StoredProcedure);
        }
        public void Update(int id, MovieModel movie, string actorids, string genreids)
        {
            var query = "Foundation.spUpdateMovie";
            var values = new { Name = movie.Name, Plot = movie.Plot, Year = movie.YearOfRelease, ProducerId = movie.ProducerId, Poster = movie.CoverImage, ActorIDs = actorids, GenreIDs = genreids, MovieID = id };
            using var connection = new SqlConnection(_connectionString);
            connection.Query(query, values, commandType: CommandType.StoredProcedure);
        }
        public void Delete(int id)
        {
            const string query = @"
                                DELETE
                                FROM Foundation.Movies
                                WHERE Id = @Id";
            Delete(query, new { id });
        }

        public List<int> GetActorIdsFromMovieActors(int movieid)
        {
            const string query = @"
              SELECT ActorId
                FROM Foundation.MovieActors
                WHERE MovieId = @movieid";

            using var connection = new SqlConnection(_connectionString);
            return connection.Query<int>(query, new { movieid }).ToList();
        }

        public void DeleteActorIdsFromMovieActors(int movieid)
        {
            const string query = @"DELETE FROM Foundation.MovieActors where MovieId = @movieid";

            using var connection = new SqlConnection(_connectionString);
            connection.Query(query, new { movieid });
        }

        public List<int> GetGenreIdsFromMovieGenres(int movieid)
        {
            const string query = @"
              SELECT GenreId
                FROM Foundation.MovieGenres
                WHERE MovieId = @movieid";

            using var connection = new SqlConnection(_connectionString);
            return connection.Query<int>(query, new { movieid }).ToList();
        }

        public void DeleteGenreIdsFromMovieGenres(int movieid)
        {
            const string query = @"DELETE FROM Foundation.MovieGenres where MovieId = @movieid";

            using var connection = new SqlConnection(_connectionString);
            connection.Query(query, new { movieid });
        }

        public void DeleteReviewsFromMovieReviews(int movieid)
        {
            const string query = @"
                                DELETE
                                FROM Foundation.Reviews
                                WHERE MovieId = @movieId";

            using var connection = new SqlConnection(_connectionString);
            connection.Query<ReviewModel>(query, new { movieid });
        }
    }
}
