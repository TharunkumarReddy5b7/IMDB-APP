using Moq;
using MovieApi.Models.DBModels;
using MovieApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Test.MockResources
{
    public class ActorMock
    {
        public static readonly Mock<IActorRepository> MockActorRepo = new Mock<IActorRepository>();

        private static List<ActorModel> ActorList = new List<ActorModel>();
        public static void SetActors()
        {
            ActorList = new List<ActorModel>()
            {
                new ActorModel
                {
                    Id = 1,
                    Name = "Prabhas",
                    Bio = "Good Actor",
                    Gender = "Male",
                    Dob = DateTime.Parse("1998/12/12")
                },
                new ActorModel
                {
                    Id = 2,
                    Name = "Rana",
                    Bio = "PowerStar",
                    Gender = "Male",
                    Dob = DateTime.Parse("1998/12/12")

                }
            };
        }

        public static void ActorMockGetAll()
        {
            MockActorRepo.Setup(x => x.GetAll()).Returns(ActorList);
        }
        public static void ActorMockGetById()
        {
            MockActorRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) =>
            {
                return ActorList.FirstOrDefault(x => x.Id == id);
            });
        }

        public static void ActorMockCreate()
        {
            MockActorRepo.Setup(x => x.Create(It.IsAny<ActorModel>())).Callback((ActorModel actor) =>
            {
                actor.Id = ActorList.Count + 1;
                ActorList.Add(actor);
            });
        }
        public static void ActorMockUpdate()
        {

            MockActorRepo.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ActorModel>())).Callback((int id, ActorModel actor) =>
            {
                var updateActor = ActorList.FirstOrDefault(x => x.Id == id);
                if (updateActor != null)
                {
                    updateActor.Name = actor.Name;
                    updateActor.Bio = actor.Bio;
                    updateActor.Gender = actor.Gender;
                    updateActor.Dob = actor.Dob;
                }
            });
        }

        public static void ActorMockDelete()
        {

            MockActorRepo.Setup(x => x.Delete(It.IsAny<int>())).Callback((int id) =>
            {
                var actor = ActorList.FirstOrDefault(x => x.Id == id);
                ActorList.Remove(actor);
            });
        }


    }
}
