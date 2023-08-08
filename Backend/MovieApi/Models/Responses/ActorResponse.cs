using System;

namespace MovieApi.Models.Responses
{
    public class ActorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
    }
}
