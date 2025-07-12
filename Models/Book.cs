namespace book_review_api.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public int ReleaseYear { get; set; }

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
