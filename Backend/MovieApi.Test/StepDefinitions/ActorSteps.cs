using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApi.Models.DBModels;
using MovieApi.Test.MockResources;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace MovieApi.Test.StepDefinitions
{
    [Scope(Feature ="Actor Resource")]
    [Binding]
    public class ActorSteps : BaseSteps
    {
        public ActorSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => ActorMock.MockActorRepo.Object);
                });
            }))
        {
        }

        [BeforeScenario("GetAllActors")]
        public static void MockGetAll()
        {
            ActorMock.SetActors();
            ActorMock.ActorMockGetAll();
        }

        [BeforeScenario("GetActorById")]
        public static void MockGetById()
        {
            ActorMock.SetActors();
            ActorMock.ActorMockGetById();
        }

        [BeforeScenario("CreateActor")]
        public static void MockCreateActor()
        {
            ActorMock.ActorMockCreate();
        }

        [BeforeScenario("UpdateActor")]
        public static void MockUpdateActor()
        {
            ActorMock.SetActors();
            ActorMock.ActorMockUpdate();
        }

        [BeforeScenario("DeleteActor")]
        public static void MockDeleteActor()
        {
            ActorMock.SetActors();
            ActorMock.ActorMockDelete();
        }
    }
}
