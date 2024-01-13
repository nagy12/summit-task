using System.Collections.Generic;

namespace MovieApplication.Models.DomainModels
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public List<MovieCategory> MovieCategories { get; set; }
    }
}
