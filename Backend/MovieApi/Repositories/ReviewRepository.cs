using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MovieApi.Controllers;
using MovieApi.Models.DBModels;
using MovieApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace MovieApi.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly string _connectionString;
        public ReviewRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value.IMDBDB;

        }
        public IList<ReviewModel> GetAll(int movieid)
        {
            const string query = @"
                                SELECT *
                                FROM Foundation.Reviews
                                WHERE MovieId = @MovieId";
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<ReviewModel>(query, new { movieid }).ToList();
        }
        public ReviewModel GetById(int movieid, int id)
        {
            const string query = @"
                                SELECT *
                                FROM Foundation.Reviews
                                WHERE MovieId = @MovieId
	                                AND Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<ReviewModel>(query, new { movieid, id });
        }
        public void Create(int movieid,ReviewModel review)
        {
            const string query = @"
                                INSERT INTO Foundation.Reviews (
	                                MovieId
	                                ,Message
	                                )
                                VALUES (
	                                @movieId
	                                ,@Message
	                                )";
            using var connection = new SqlConnection(_connectionString);
            connection.Query<ReviewModel>(query, new { movieid, review.Message });
        }
        public void Update(int movieid, int id, ReviewModel review)
        {
            const string query = @"
                                UPDATE Foundation.Reviews
                                SET Message = @Message
                                WHERE Id = @Id
	                                AND MovieId = @MovieId";
            using var connection = new SqlConnection(_connectionString);
            connection.Query<ReviewModel>(query, new { review.Message, id, movieid });
        }
        public void Delete(int movieid, int id)
        {
            const string query = @"
                                DELETE
                                FROM Foundation.Reviews
                                WHERE MovieId = @movieId
	                                AND Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            connection.Query<ReviewModel>(query, new { movieid, id });
        }

       
    }
}
