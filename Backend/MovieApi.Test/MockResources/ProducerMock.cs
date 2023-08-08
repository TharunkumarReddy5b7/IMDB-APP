using Microsoft.Identity.Client;
using Moq;
using MovieApi.Models.DBModels;
using MovieApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Test.MockResources
{
    public class ProducerMock
    {
        public static readonly Mock<IProducerRepository> MockProducerRepo = new Mock<IProducerRepository>();
        private static List<ProducerModel> producerList = new List<ProducerModel>();
        public static void SetProducers()
        {
            producerList = new List<ProducerModel>
            {
                new ProducerModel
                {
                    Id = 1,
                    Name = "Shobu",
                    Bio = "Good Producer",
                    Gender = "Male",
                    Dob = DateTime.Parse("1998/12/12")
                },
                new ProducerModel
                {
                    Id = 2,
                    Name = "Viswak",
                    Bio = "Star Producer",
                    Gender = "Male",
                    Dob = DateTime.Parse("1998/12/12")
                }
            };
        }
        public static void ProducerMockGetAll()
        {
            MockProducerRepo.Setup(x => x.GetAll()).Returns(producerList);
        }
        public static void ProducerMockGetById()
        {
            MockProducerRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) =>
            {
                return producerList.FirstOrDefault(x => x.Id == id);
            });
        }

        public static void ProducerMockCreate()
        {
            MockProducerRepo.Setup(x => x.Create(It.IsAny<ProducerModel>())).Callback((ProducerModel producer) =>
            {
                producer.Id = producerList.Count() + 1;
                producerList.Add(producer);
            });
        }
        public static void ProducerMockUpdate()
        {

            MockProducerRepo.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ProducerModel>())).Callback((int id, ProducerModel producer) =>
            {
                var updateProducer = producerList.FirstOrDefault(x => x.Id == id);
                if (updateProducer != null)
                {
                    updateProducer.Name = producer.Name;
                    updateProducer.Bio = producer.Bio;
                    updateProducer.Gender = producer.Gender;
                    updateProducer.Dob = producer.Dob;

                }
            });
        }

        public static void ProducerMockDelete()
        {
            MockProducerRepo.Setup(x => x.Delete(It.IsAny<int>())).Callback((int id) =>
            {
                var producer = producerList.FirstOrDefault(x => x.Id == id);
                producerList.Remove(producer);
            });
        }

    }
}
