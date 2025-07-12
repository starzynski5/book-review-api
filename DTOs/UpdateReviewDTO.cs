namespace book_review_api.DTOs
{
    public class UpdateReviewDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Stars { get; set; }
    }
}
