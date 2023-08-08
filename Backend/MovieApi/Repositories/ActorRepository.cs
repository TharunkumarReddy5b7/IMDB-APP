using Dapper;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MovieApi.Models.DBModels;
using MovieApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieApi.Repositories
{
    public class ActorRepository :BaseRepository<ActorModel>, IActorRepository
    {
        private readonly string _connectionString;
        public ActorRepository(IOptions<ConnectionString> connectionString)
            :base(connectionString.Value.IMDBDB)
        {
            _connectionString = connectionString.Value.IMDBDB;
        }
        public IList<ActorModel> GetAll()
        {
            const string query = @"
                    SELECT Id
	                    ,Name
	                    ,Bio
	                    ,Dob
	                    ,Gender
                    FROM Foundation.Actors";

            return GetAll(query).ToList();
        }
        public ActorModel GetById(int id)
        {
            const string query = @"
              SELECT Id
	                ,Name
	                ,Bio
	                ,Dob
	                ,Gender
                FROM Foundation.Actors
                WHERE Id = @Id ";

            return GetById(query, new { id });
        }
        public void Create(ActorModel actor)
        {
            const string query = @"
            INSERT INTO Foundation.Actors (
	                    Name
	                    ,Bio
	                    ,Dob
	                    ,Gender
	                    )
                    VALUES (
	                    @Name
	                    ,@Bio
	                    ,@Dob
	                    ,@Gender
	                    )";

            Create(query, new { actor.Name, actor.Bio, actor.Dob, actor.Gender });
        }
        public void Update(int id, ActorModel actor)
        {
            const string query = @"
            UPDATE Foundation.Actors
            SET Name = @Name
	            ,Bio = @Bio
	            ,Gender = @Gender
	            ,Dob = @Dob
            WHERE Id = @Id";

            Update(query, new { actor.Name, actor.Bio, actor.Dob, actor.Gender, id });
        }
        public void Delete(int id)
        {
            const string query = @"
            DELETE
            FROM Foundation.Actors
            WHERE Id = @id";

            Delete(query, new { id });
        }
   
    }
}
