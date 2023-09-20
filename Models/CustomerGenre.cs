namespace Chinook.Models
{
    public class CustomerGenre
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public List<string> PopularGenres { get; set; }

    }
}
