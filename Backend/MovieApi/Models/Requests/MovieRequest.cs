using System.Collections.Generic;
namespace MovieApi.Models.Requests
{
    public class MovieRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public List<int> Actorids { get; set; }
        public List<int> Genreids { get; set; }
        public string CoverImage { get; set; }
        public int ProducerId { get; set; } 
    }
}
