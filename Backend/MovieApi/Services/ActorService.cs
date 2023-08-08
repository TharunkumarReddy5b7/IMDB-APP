using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client;
using MovieApi.Models.DBModels;
using MovieApi.Models.Requests;
using MovieApi.Models.Responses;
using MovieApi.Repositories.Interfaces;
using MovieApi.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace MovieApi.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        public ActorService(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }
        public IList<ActorResponse> GetAll()
        {

            var actorsList = _actorRepository.GetAll();
            if (actorsList == null)
            {
                return new List<ActorResponse>();
            }
            return _mapper.Map<List<ActorResponse>>(actorsList);
        }
        public ActorResponse GetById(int id)
        {
            if( id <= 0)
            {
                throw new Exception("Invalid ActorId");
            }
            var actor = _actorRepository.GetById(id);
            if (actor == null)
            {
                throw new Exception($"Actor with ID {id} not found");
            }
            return _mapper.Map<ActorResponse>(actor);
        }
        public void Create(ActorRequest request)
        {
            ValidateRequest(request);
            var actor = _mapper.Map<ActorModel>(request);
            _actorRepository.Create(actor);
        }
        public void Update(int id, ActorRequest request)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid ActorId");
            }
            var actor = _actorRepository.GetById(id);
            if (actor == null)
            {
                throw new Exception($"Actor with Id {id} not found");
            }

            ValidateRequest(request);

            var updatedActor = _mapper.Map<ActorModel>(request);
            _actorRepository.Update(id, updatedActor);
        }
        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid ActorId");
            }
            if (_actorRepository.GetById(id) == null)
            {
                throw new Exception($"Actor with Id {id} does not found");
            }
            _actorRepository.Delete(id);
        }
        private void ValidateRequest(ActorRequest actor)
        {

            if (string.IsNullOrEmpty(actor.Name))
            {
                throw new Exception("Actor name can not be empty");
            }
            if (string.IsNullOrEmpty(actor.Bio))
            {
                throw new Exception("Bio can not be empty");
            }
            try
            {
                Convert.ToDateTime(actor.Dob);
            }
            catch (Exception) { throw new Exception("Provide valid Dob"); }

            if (string.IsNullOrEmpty(actor.Gender))
            {
                throw new Exception("Gender can not be empty");
            }
        }
    }
}
