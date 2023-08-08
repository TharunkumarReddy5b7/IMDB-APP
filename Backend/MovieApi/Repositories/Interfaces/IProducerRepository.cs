using MovieApi.Models.DBModels;
using System.Collections.Generic;

namespace MovieApi.Repositories.Interfaces
{
    public interface IProducerRepository
    {
        public IList<ProducerModel> GetAll();
        public ProducerModel GetById(int id);
        public void Create(ProducerModel actor);
        public void Update(int id, ProducerModel actor);
        public void Delete(int id);
    }
}
