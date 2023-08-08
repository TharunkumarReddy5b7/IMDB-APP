using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApi.Models.DBModels;
using MovieApi.Test.MockResources;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;
using Gherkin.Ast;

namespace MovieApi.Test.StepDefinitions
{
    [Scope(Feature="Genre Resource")]
    [Binding]
    public class GenreSteps:BaseSteps
    {
        public GenreSteps(CustomWebApplicationFactory factory)
           : base(factory.WithWebHostBuilder(builder =>
           {
               builder.ConfigureServices(services =>
               {
                   services.AddScoped(_ => GenreMock.MockGenreRepo.Object);
               });
           }))
        {
        }

        [BeforeScenario("GetAllGenres")]
        public static void MockGetAll()
        {
            GenreMock.SetGenres();
            GenreMock.GenreMockGetAll();
        }

        [BeforeScenario("GetGenreById")]
        public static void MockGetById()
        {
            GenreMock.SetGenres();
            GenreMock.GenreMockGetById();
        }

        [Before("CreateGenre")]
        public static void MockCreateGenre()
        {
            GenreMock.GenreMockCreate();
        }

        [Before("UpdateGenre")]
        public static void MockUpdateGenre()
        {
            GenreMock.SetGenres();
            GenreMock.GenreMockUpdate();
        }

        [Before("DeleteGenre")]
        public static void MockDeleteGenre()
        {
            GenreMock.SetGenres();
            GenreMock.GenreMockDelete();
        }

    }
}
