using Dapper;
using Microsoft.Data.SqlClient;
using MovieApi.Models.DBModels;
using System.Collections.Generic;
using System.Data;

namespace MovieApi.Repositories
{
    public class BaseRepository<T> where T : class
    {
        private readonly string _connectionString;
        public BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<T> GetAll(string query)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<T>(query);
        }
        public T GetById(string query, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<T>(query, parameters);
        }
        public void Create(string query, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Query<T>(query, parameters);
        }
        public void Update(string query, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Query<T>(query, parameters);
        }
        public void Delete(string query, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Query<T>(query, parameters);
        }
    }
}
