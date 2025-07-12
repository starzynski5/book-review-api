namespace book_review_api.Models
{
    public class Book
    {
        private readonly int Id;

        private string Title { get { return Title; } set { Title = value; } }

        private string Description { get { return Description; } set { Description = value; } }

        private string Author {  get { return Author; } set { Author = value; } }

        private int ReleaseYear { get { return ReleaseYear; } set { ReleaseYear = value; } }

        //list of reviews
    }
}
