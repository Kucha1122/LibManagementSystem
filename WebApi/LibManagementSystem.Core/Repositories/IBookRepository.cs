using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Domain.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetByTitle(string title);
        Task<IEnumerable<Book>> GetBooksWithAuthors();
        Task<Book> GetBookWithAuthors(int id);
        Task<IEnumerable<Book>> GetIssuedBooks();
        Task<IEnumerable<Book>> GetAvailableBooks();
    }
}