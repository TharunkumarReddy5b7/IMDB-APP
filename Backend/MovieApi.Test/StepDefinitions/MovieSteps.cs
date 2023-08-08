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
    [Scope(Feature= "Movie Resource")]
    [Binding]
    public class MovieSteps:BaseSteps
    {
        public MovieSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => MovieMock.MocKMovieRepo.Object);
                    services.AddScoped(_ => ActorMock.MockActorRepo.Object);
                    services.AddScoped(_ => ProducerMock.MockProducerRepo.Object);
                    services.AddScoped(_ => GenreMock.MockGenreRepo.Object);

                });
            }))
        {
        }

        [BeforeScenario("GetAllMovies")]
        public static void MockGetAll()
        {
            ActorMock.SetActors();
            ProducerMock.SetProducers();
            GenreMock.SetGenres();
            MovieMock.SetMovies();
            MovieMock.MockGetGenreIds();
            MovieMock.MockGetActorIds();
            ActorMock.ActorMockGetById();
            ProducerMock.ProducerMockGetById();
            GenreMock.GenreMockGetById();
            MovieMock.MovieMockGetAll();
        }

        [BeforeScenario("GetMovieById")]
        public static void MockGetById()
        {
            ActorMock.SetActors();
            ProducerMock.SetProducers();
            GenreMock.SetGenres();
            MovieMock.SetMovies();
            MovieMock.MockGetGenreIds();
            MovieMock.MockGetActorIds();
            ActorMock.ActorMockGetById();
            ProducerMock.ProducerMockGetById();
            GenreMock.GenreMockGetById();
            MovieMock.MovieMockGetById();
        }

        [BeforeScenario("CreateMovie")]
        public static void MockCreateMovie()
        {
            ActorMock.SetActors();
            ProducerMock.SetProducers();
            GenreMock.SetGenres();
            MovieMock.SetMovies();
            ActorMock.ActorMockGetById();
            ProducerMock.ProducerMockGetById();
            GenreMock.GenreMockGetById();
            MovieMock.MovieMockCreate();
        }

        [BeforeScenario("UpdateMovie")]
        public static void MockUpdateMovie()
        {
            ActorMock.SetActors();
            ProducerMock.SetProducers();
            GenreMock.SetGenres();
            MovieMock.SetMovies();
            ActorMock.ActorMockGetById();
            ProducerMock.ProducerMockGetById();
            GenreMock.GenreMockGetById();
            MovieMock.MovieMockGetById();
            MovieMock.MovieMockUpdate();
        }

        [BeforeScenario("DeleteMovie")]
        public static void MockDeleteMovie()
        {
            MovieMock.SetMovies();
            MovieMock.MovieMockGetById();
            MovieMock.MockDeleteActorIds();
            MovieMock.MockDeleteGenreIds();
            MovieMock.MovieMockDelete();
        }

        
    }
}
