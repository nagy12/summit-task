using System.Collections.Generic;

namespace MovieApplication.Models.DomainModels
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public string CoverImage { get; set; }

        // Navigation properties
        public List<MovieCategory> MovieCategories { get; set; }
    }
}
