using MovieApi.Models.DBModels;
using System.Collections.Generic;

namespace MovieApi.Repositories.Interfaces
{
    public interface IActorRepository
    {
        public IList<ActorModel> GetAll();
        public ActorModel GetById(int id);
        public void Create(ActorModel actor);
        public void Update(int id, ActorModel actor);
        public void Delete(int id);       
       
    }
}
