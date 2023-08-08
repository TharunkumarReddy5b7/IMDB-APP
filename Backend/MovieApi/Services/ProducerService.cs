using AutoMapper;
using MovieApi.Models.DBModels;
using MovieApi.Models.Requests;
using MovieApi.Models.Responses;
using MovieApi.Repositories.Interfaces;
using MovieApi.Services.Interfaces;
using System.Collections.Generic;
using System;

namespace MovieApi.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IMapper _mapper;
        public ProducerService(IProducerRepository producerRepository, IMapper mapper)
        {
            _producerRepository = producerRepository;
            _mapper = mapper;
        }
        public IList<ProducerResponse> GetAll()
        {
            var producerList = _producerRepository.GetAll();

            if (producerList == null)
            {
                return new List<ProducerResponse>();
            }
            return _mapper.Map<List<ProducerResponse>>(producerList);
        }
        public ProducerResponse GetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid ProducerId");
            }
            var producer = _producerRepository.GetById(id);
            if (producer == null)
            {
                throw new Exception($"Producer with Id {id} not found");
            }
            return _mapper.Map<ProducerResponse>(producer);
        }
        public void Create(ProducerRequest request)
        {
            ValidateRequest(request);
            var producer = _mapper.Map<ProducerModel>(request);
            
            _producerRepository.Create(producer);
           
        }
        public void Update(int id, ProducerRequest request)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid ProducerId");
            }
            var producer = _producerRepository.GetById(id);
            if (producer == null)
            {
                throw new Exception($"Producer with Id {id} not found");
            }
            ValidateRequest(request);
            var updatedProducer = _mapper.Map<ProducerModel>(request);
            

            _producerRepository.Update(id, updatedProducer);
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid ProducerId");
            }
            if (_producerRepository.GetById(id) == null)
            {
                throw new Exception($"Producer with Id {id} does not found");
            }
            _producerRepository.Delete(id);
        }

        private void ValidateRequest(ProducerRequest producer)
        {
            if (string.IsNullOrEmpty(producer.Name))
            {
                throw new Exception("Producer name can not be empty");
            }
            if (string.IsNullOrEmpty(producer.Bio))
            {
                throw new Exception("Bio can not be empty");
            }
            try
            {
                Convert.ToDateTime(producer.Dob);
            }
            catch (Exception) { throw new Exception("Provide valid Dob"); }

            if (string.IsNullOrEmpty(producer.Gender))
            {
                throw new Exception("Gender can not be empty");
            }

        }
    }
}
