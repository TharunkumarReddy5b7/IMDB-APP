﻿namespace MovieApi.Models.Requests
{
    public class ReviewRequest
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int MovieId { get; set; }
    }
}
