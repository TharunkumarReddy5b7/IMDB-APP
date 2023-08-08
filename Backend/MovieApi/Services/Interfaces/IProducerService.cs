using MovieApi.Models.Requests;
using MovieApi.Models.Responses;
using System.Collections.Generic;

namespace MovieApi.Services.Interfaces
{
    public interface IProducerService
    {
        public IList<ProducerResponse> GetAll();
        public ProducerResponse GetById(int id);
        public void Create(ProducerRequest actor);
        public void Update(int id, ProducerRequest actor);
        public void Delete(int id);
    }
}
