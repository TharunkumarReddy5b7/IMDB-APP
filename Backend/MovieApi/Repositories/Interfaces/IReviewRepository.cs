using MovieApi.Models.DBModels;
using System.Collections.Generic;

namespace MovieApi.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        public IList<ReviewModel> GetAll(int movieid);
        public ReviewModel GetById(int movieid, int id);
        public void Create(int movieid,ReviewModel review);
        public void Update(int movieid, int id, ReviewModel review);
        public void Delete(int movieid, int id);
       
    }
}
