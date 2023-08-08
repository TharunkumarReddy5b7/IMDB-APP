using MovieApi.Models.DBModels;
using MovieApi.Models.Requests;
using MovieApi.Models.Responses;
using System.Collections.Generic;

namespace MovieApi.Services.Interfaces
{
    public interface IActorService
    {
        public IList<ActorResponse> GetAll();
        public ActorResponse GetById(int id);
        public void Create(ActorRequest actor);
        public void Update(int id,ActorRequest actor);
        public void Delete(int id);
      
    }
}
