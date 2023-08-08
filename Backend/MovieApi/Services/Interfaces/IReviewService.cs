using MovieApi.Models.Requests;
using MovieApi.Models.Responses;
using System.Collections.Generic;

namespace MovieApi.Services.Interfaces
{
    public interface IReviewService
    {
        public IList<ReviewResponse> GetAll(int movieid);
        public ReviewResponse GetById(int movieid, int id);
        public void Create(int movieid, ReviewRequest review);
        public void Update(int movieid, int id, ReviewRequest review);
        public void Delete(int movieid, int id);
    }
}
