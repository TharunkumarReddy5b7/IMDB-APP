using AutoMapper;
using MovieApi.Models.DBModels;
using MovieApi.Models.Requests;
using MovieApi.Models.Responses;
using System.Runtime.Intrinsics.Arm;

namespace MovieApi.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {

            CreateMap<ProducerModel,ProducerResponse>().ReverseMap();

            CreateMap<ProducerModel, ProducerRequest>().ReverseMap();

            CreateMap<ActorModel, ActorResponse>().ReverseMap();

            CreateMap<ActorModel, ActorRequest>().ReverseMap();

            CreateMap<GenreModel,GenreResponse>().ReverseMap();

            CreateMap<GenreModel, GenreRequest>().ReverseMap();

            CreateMap<ReviewModel, ReviewResponse>().ReverseMap();

            CreateMap<ReviewModel, ReviewRequest>().ReverseMap();

            CreateMap<MovieModel, MovieResponse>().ReverseMap();

            CreateMap<MovieModel, MovieRequest>().ReverseMap();
        }
    }
}
