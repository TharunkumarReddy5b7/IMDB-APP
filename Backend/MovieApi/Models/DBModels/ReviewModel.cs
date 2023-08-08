namespace MovieApi.Models.DBModels
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int MovieId { get; set; }
    }
}
