using Library.Models;
using Library.Services.Models;

namespace Library.Services
{
    public interface IBookService
    {
        Task<List<BookAllViewModel>> GetAllBooksAsync();

        Task AddBookAsync(BookAddModel model);

        Task EditBookAsync(int bookId, BookEditModel model);

        Task<List<CategoryViewModel>> GetAllCategoriesAsync();
        Task<List<BookMineViewModel>> GetAllMineBookAsync(string userId);
        Task AddBookToMineAsync(int bookId, string userId);
        Task RemoveBookFromMineAsync(int bookId, string userId);
    }
}
