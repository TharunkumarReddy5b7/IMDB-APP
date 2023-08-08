using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MovieApi.Models.DBModels;
using MovieApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MovieApi.Repositories
{
    public class GenreRepository :BaseRepository<GenreModel>, IGenreRepository
    {
        private readonly string _connectionString;
        public GenreRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDBDB)
        {
            _connectionString = connectionString.Value.IMDBDB;
        }
        public IList<GenreModel> GetAll()
        {
            const string query = @"
                            SELECT Id
	                            ,Name
                            FROM Foundation.Genres";
            return GetAll(query).ToList();
        }
        public GenreModel GetById(int id)
        {
            const string query = @"
                            SELECT Id
	                            ,Name
                            FROM Foundation.Genres
                            WHERE Id = @Id";

            return GetById(query, new { id });
        }
        public void Create(GenreModel genre)
        {
            const string query = @"
                            INSERT INTO Foundation.Genres (Name)
                            VALUES (@Name)";
            Create(query, new { genre.Name });
        }
        public void Update(int id, GenreModel genre)
        {
            const string query = @"
                            UPDATE Foundation.Genres
                            SET Name = @Name
                            WHERE Id = @id";
            Update(query, new { genre.Name, id });
        }
        public void Delete(int id)
        {
            const string query = @"
                            DELETE
                            FROM Foundation.Genres
                            WHERE Id = @id";
            Delete(query, new { id }); ;
        }
        

    }
}
