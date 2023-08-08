using Microsoft.Extensions.Options;
using MovieApi.Models.DBModels;
using MovieApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MovieApi.Repositories
{
    public class ProducerRepository :BaseRepository<ProducerModel>, IProducerRepository
    {
        public ProducerRepository(IOptions<ConnectionString> connectionString)
              : base(connectionString.Value.IMDBDB)
        {
        }

        public IList<ProducerModel> GetAll()
        {
            const string query = @"
                                SELECT Id
	                                ,Name
	                                ,Bio
	                                ,Gender
                                FROM Foundation.Producers";

            return GetAll(query).ToList();
        }
        public ProducerModel GetById(int id)
        {
            const string query = @"
                                SELECT Id
	                                ,Name
	                                ,Bio
	                                ,Gender
                                FROM Foundation.producers
                                WHERE Id = @Id";

            return GetById(query, new { id });
        }
        public void Create(ProducerModel producer)
        {
            const string query = @"
                                INSERT INTO Foundation.Producers (
	                                Name
	                                ,Bio
	                                ,Gender
	                                ,Dob
	                                )
                                VALUES (
	                                @Name
	                                ,@Bio
	                                ,@Gender
	                                ,@Dob
	                                )";
            Create(query, new { @producer.Name, @producer.Bio, @producer.Gender, @producer.Dob });
        }
        public void Update(int id, ProducerModel producer)
        {
            const string query = @"
                                UPDATE Foundation.Producers
                                SET name = @name
	                                ,bio = @bio
	                                ,gender = @gender
	                                ,dob = @dob
                                WHERE Id = @Id";

            Update(query, new { producer.Name, producer.Bio, producer.Dob, producer.Gender, id });
        }
        public void Delete(int id)
        {
            const string query = @"
                                DELETE
                                FROM FOUNDATION.Producers
                                WHERE Id = @id";
            Delete(query, new { id });
        }
    }
}
