using System.Collections.Generic;
using System.Globalization;

namespace MovieApi.Models.DBModels
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public int ProducerId { get; set; }
        public string CoverImage { get; set; }
    }
}
