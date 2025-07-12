using System.Text.Json.Serialization;

namespace book_review_api.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAtDate { get; set; } = DateTime.Now;

        public int Stars { get; set; }

        public int BookId { get; set; }

        [JsonIgnore]
        public Book Book { get; set; }

    }
}
