using book_review_api.Data;
using book_review_api.DTOs;
using book_review_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace book_review_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        public readonly BookReviewContext _context;

        public ReviewController(BookReviewContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Review>>> GetAllReviews()
        {
            List<Review> reviews = await _context.Reviews
                .Include(r => r.Book)
                .ToListAsync();

            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReviewById(int id)
        {
            Review review = await _context.Reviews
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        [HttpPost]
        public async Task<ActionResult<Review>> CreateReview(CreateReviewDTO review)
        {
            if (review == null)
            {
                return BadRequest();
            }

            Book book = await _context.Books
                .Where(b => b.Id == review.BookId)
                .FirstOrDefaultAsync();

            if (book == null)
            {
                return NotFound("Book not found");
            }

            Review newReview = new Review();
            newReview.Content = review.Content;
            newReview.Stars = review.Stars;
            newReview.BookId = review.BookId;
            newReview.Book = book;

            _context.Reviews.Add(newReview);

            book.Reviews.Add(newReview);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReviewById), new { id = newReview.Id }, newReview);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, UpdateReviewDTO updatedReview)
        {
            if (updatedReview == null)
            {
                return BadRequest();
            }

            Review review = await _context.Reviews
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();

            if (review == null)
            {
                return NotFound("Review not found");
            }

            review.Content = updatedReview.Content;
            review.Stars = updatedReview.Stars;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            Review review = await _context.Reviews
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();

            if (review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
