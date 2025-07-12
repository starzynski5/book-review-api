using book_review_api.Models;
using Microsoft.EntityFrameworkCore;

namespace book_review_api.Data
{
    public class BookReviewContext : DbContext
    {
        public BookReviewContext(DbContextOptions<BookReviewContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
