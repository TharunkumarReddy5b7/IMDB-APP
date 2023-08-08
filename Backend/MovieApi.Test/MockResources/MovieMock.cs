using Dapper;
using Moq;
using MovieApi.Models.DBModels;
using MovieApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Test.MockResources
{
    public class MovieMock
    {
        public static readonly Mock<IMovieRepository> MocKMovieRepo = new Mock<IMovieRepository>();

        private static List<MovieModel> MovieList= new List<MovieModel>();
        private static Dictionary<int, List<int>> MovieActors = new Dictionary<int, List<int>>();
        private static Dictionary<int, List<int>> MovieGenres = new Dictionary<int, List<int>>();
        public static void SetMovies()
        {
            MovieList = new List<MovieModel>()
            {
                new MovieModel
                {
                    Id = 1,
                    Name = "RRR",
                    Plot = "Story Movie",
                    YearOfRelease = 2018,
                    CoverImage = "Link",
                    ProducerId = 1
                },
                new MovieModel
                {
                    Id = 2,
                    Name = "Robo",
                    Plot = "Technical Movie",
                    YearOfRelease = 2019,
                    CoverImage = "Link",
                    ProducerId = 1

                }
            };
        }
        
        public static void MovieMockGetAll()
        {
            MovieActors = new Dictionary<int, List<int>>
            {
                {1, new List<int>(){1,2}},
                {2, new List<int>(){1,2}}
            };
            MovieGenres = new Dictionary<int, List<int>>
            {
                {1, new List<int>(){1}},
                {2, new List<int>(){2}}
            };
            MocKMovieRepo.Setup(x => x.GetAll()).Returns(MovieList);
        }
        public static void MovieMockGetById()
        {
            MovieActors = new Dictionary<int, List<int>>
            {
                {1, new List<int>(){1,2}},
                {2, new List<int>(){1,2}}
            };
            MovieGenres = new Dictionary<int, List<int>>
            {
                {1, new List<int>(){1}},
                {2, new List<int>(){2}}
            };

            MocKMovieRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) =>
            {
                return MovieList.FirstOrDefault(x => x.Id == id);
            });

        }

        public static void MovieMockCreate()
        {

            MocKMovieRepo.Setup(x => x.Create(It.IsAny<MovieModel>(), It.IsAny<string>(), It.IsAny<string>())).Callback((MovieModel movie, string actorIds, string genreIds) =>
            {
                var movieActorIds = (actorIds.Split(",")).Select(Int32.Parse).ToList();
                var movieGenreIds = (genreIds.Split(",")).Select(Int32.Parse).ToList();
                movie.Id = MovieList.Count + 1;
                MovieActors.Add(movie.Id, movieActorIds);
                MovieGenres.Add(movie.Id, movieGenreIds);
                MovieList.Add(movie);
            });
        }
        public static void MovieMockUpdate()
        {
            MovieActors = new Dictionary<int, List<int>>
            {
                {1, new List<int>(){1,2}},
                {2, new List<int>(){1,2}}
            };
            MovieGenres = new Dictionary<int, List<int>>
            {
                {1, new List<int>(){1}},
                {2, new List<int>(){2}}
            };

            MocKMovieRepo.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<MovieModel>(), It.IsAny<string>(), It.IsAny<string>())).Callback((int id, MovieModel movie, string actorIds, string genreIds) =>
            {
                var updateMovie = MovieList.FirstOrDefault(x => x.Id == id);
                if (updateMovie != null)
                {
                    updateMovie.Name = movie.Name;
                    updateMovie.Plot = movie.Plot;
                    updateMovie.ProducerId = movie.ProducerId;
                    updateMovie.CoverImage = movie.CoverImage;
                    updateMovie.YearOfRelease = movie.YearOfRelease;
                }
                var movieActorIds = (actorIds.Split(",")).Select(Int32.Parse).ToList();
                var movieGenreIds = (genreIds.Split(",")).Select(Int32.Parse).ToList();
                if (MovieActors.ContainsKey(id))
                {
                    MovieActors[id] = movieActorIds;
                }
                else
                {
                    MovieActors.Add(id, movieActorIds);

                }

                if (MovieGenres.ContainsKey(id))
                {
                    MovieGenres[id] = movieGenreIds;

                }
                else
                {
                    MovieGenres.Add(id, movieGenreIds);
                }
            });
        }

        public static void MovieMockDelete()
        {
            MovieActors = new Dictionary<int, List<int>>
            {
                {1, new List<int>(){1,2}},
                {2, new List<int>(){1,2}}
            };
            MovieGenres = new Dictionary<int, List<int>>
            {
                {1, new List<int>(){1}},
                {2, new List<int>(){2}}
            };
            MocKMovieRepo.Setup(x => x.Delete(It.IsAny<int>())).Callback((int id) =>
            {
                var movie = MovieList.FirstOrDefault(x => x.Id == id);
                MovieList.Remove(movie);
            });
        }

        public static void MockGetActorIds()
        {

            MocKMovieRepo.Setup(x => x.GetActorIdsFromMovieActors(It.IsAny<int>())).Returns((int id) =>
            {
                MovieActors.TryGetValue(id, out List<int> value);

                return value;
            });

        }

        public static void MockGetGenreIds()
        {
            MocKMovieRepo.Setup(x => x.GetGenreIdsFromMovieGenres(It.IsAny<int>())).Returns((int id) =>
            {
                MovieGenres.TryGetValue(id, out List<int> value);

                return value;
            });

        }

        public static void MockDeleteActorIds()
        {
            MocKMovieRepo.Setup(x => x.DeleteGenreIdsFromMovieGenres(It.IsAny<int>())).Callback((int id) =>
            {
                MovieGenres.Remove(id);
            });

        }

        public static void MockDeleteGenreIds()
        {
            MocKMovieRepo.Setup(x => x.DeleteGenreIdsFromMovieGenres(It.IsAny<int>())).Callback((int id) =>
            {
                MovieGenres.Remove(id);
            });


        }
    }
}
