using Library.Data;
using Library.Data.Entites;
using Library.Models;
using Library.Services.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext _context)
        {
            context = _context;
        }

        public async Task AddBookAsync(BookAddModel model)
        {
            Book book = new Book()
            {
                Title = model.Title,
                Description = model.Description,
                Author = model.Author,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                Rating = model.Rating,
            };

            await this.context.Books.AddAsync(book);
            await this.context.SaveChangesAsync();
        }

        public async Task AddBookToMineAsync(int bookId, string userId)
        {
            if (userId == null)
            {
                throw new ArgumentException("Method: AddBookToMineAsync - User is null");
            };

            Book? book = await this.context.Books.FindAsync(bookId);

            if (book == null)
            {
                throw new ArgumentException("Method: AddBookToMineAsync - Book is null");
            }

            ApplicationUserBook? applicationUserBook = await this.context
               .ApplicationUsersBooks
               .Where(a => a.ApplicationUserId == userId && a.BookId == bookId)
               .FirstOrDefaultAsync();

            if (applicationUserBook != null)
            {
                throw new ArgumentException("Method: AddBookToMineAsync - ApplicationBookUser is not null");
            }

             applicationUserBook = new ApplicationUserBook()
            {
                ApplicationUserId = userId,
                Book = book,
                BookId = book.Id
            };

            await this.context.ApplicationUsersBooks.AddAsync(applicationUserBook);
            await this.context.SaveChangesAsync();
        }

        public Task EditBookAsync(int bookId, BookEditModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BookAllViewModel>> GetAllBooksAsync()
        {
            return await this.context
                .Books
                .Select(b => new BookAllViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating  = b.Rating,
                    Category = b.Category.Name,
                })
                .ToListAsync();
        }

        public async Task<List<CategoryViewModel>> GetAllCategoriesAsync()
        {
            return await this.context
                .Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<List<BookMineViewModel>> GetAllMineBookAsync(string userId)
        {
            if(userId == null)
            {
                throw new ArgumentException("Method GetAllMineBookAsync - User is null");
            }

            return await this.context
                .ApplicationUsersBooks
                .Where(a => a.ApplicationUserId == userId)
                .Select(a => new BookMineViewModel()
                {
                    Id = a.BookId, 
                    Title = a.Book.Title,
                    Author = a.Book.Author,
                    Description = a.Book.Description,
                    ImageUrl = a.Book.ImageUrl,
                    Category = a.Book.Category.Name,
                })
                .ToListAsync();
        }

        public async Task RemoveBookFromMineAsync(int bookId, string userId)
        {
            if (userId == null)
            {
                throw new ArgumentException("Method: RemoveBookFromMineAsync - User is null");
            };

            Book? book = await this.context.Books.FindAsync(bookId);

            if (book == null)
            {
                throw new ArgumentException("Method: RemoveBookFromMineAsync - Book is null");
            }

            ApplicationUserBook? applicationUserBook = await this.context
                .ApplicationUsersBooks
                .Where(a => a.ApplicationUserId == userId && a.BookId == bookId)
                .FirstOrDefaultAsync();

            if(applicationUserBook == null)
            {
                throw new ArgumentException("Method: RemoveBookFromMineAsync - ApplicationBookUser is null");
            }

            this.context.ApplicationUsersBooks.Remove(applicationUserBook);
            await this.context.SaveChangesAsync();
        }
    }
}
