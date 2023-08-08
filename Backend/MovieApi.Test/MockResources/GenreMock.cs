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
    public class GenreMock
    {
        public static readonly Mock<IGenreRepository> MockGenreRepo = new Mock<IGenreRepository>();

        private static List<GenreModel> GenreList = new List<GenreModel>();
        public static void SetGenres()
        {
            GenreList = new List<GenreModel>()
            {
                new GenreModel()
                {
                    Id= 1,
                    Name="Action"
                },
                new GenreModel()
                {
                    Id= 2,
                    Name="Drama"
                }
            };
        }

        public static void GenreMockGetAll()
        {
            MockGenreRepo.Setup(x => x.GetAll()).Returns(GenreList);
        }
        public static void GenreMockGetById()
        {
            MockGenreRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) =>
            {
                return GenreList.FirstOrDefault(x => x.Id == id);
            });
        }

        public static void GenreMockCreate()
        {
            MockGenreRepo.Setup(x => x.Create(It.IsAny<GenreModel>())).Callback((GenreModel genre) =>
            {
                genre.Id = GenreList.Count + 1;
                GenreList.Add(genre);
            });
        }
        public static void GenreMockUpdate()
        {

            MockGenreRepo.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<GenreModel>())).Callback((int id, GenreModel genre) =>
            {
                var updateGenre = GenreList.FirstOrDefault(x => x.Id == id);
                if (updateGenre != null)
                {
                    updateGenre.Name = genre.Name;
                }
            });

        }

        public static void GenreMockDelete()
        {

            MockGenreRepo.Setup(x => x.Delete(It.IsAny<int>())).Callback((int id) =>
            {
                var genre = GenreList.FirstOrDefault(x => x.Id == id);
                GenreList.Remove(genre);
            });
        }

    }
}
