namespace book_review_api.DTOs
{
    public class CreateReviewDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Stars { get; set; }

        public int BookId { get; set; }
    }
}
