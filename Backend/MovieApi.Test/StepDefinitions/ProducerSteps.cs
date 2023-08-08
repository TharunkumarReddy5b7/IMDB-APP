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
    [Scope(Feature = "Producer Resource")]
    [Binding]
    public class ProducerSteps:BaseSteps
    {
        public ProducerSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => ProducerMock.MockProducerRepo.Object);
                });
            }))
        {
        }

        [BeforeScenario("GetAllProducers")]
        public static void MockGetAll()
        {   
                ProducerMock.SetProducers();
                ProducerMock.ProducerMockGetAll();
            
        }

        [BeforeScenario("GetProducerById")]   
        public static void MockGetById()
        {
            
           ProducerMock.SetProducers();
           ProducerMock.ProducerMockGetById();
            
        }

        [BeforeScenario("CreateProducer")]
        public static void MockCreateProducer()
        {
           ProducerMock.ProducerMockCreate();
        }


        [BeforeScenario("UpdateProducer")]
        public static void MockUpdateProducer()
        {
            ProducerMock.SetProducers();
            ProducerMock.ProducerMockUpdate();
        }

        [BeforeScenario("DeleteProducer")]
        public static void MockDeleteProducer()
        {
            ProducerMock.SetProducers();
            ProducerMock.ProducerMockDelete();
        }

    }

    
}
