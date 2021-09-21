using System.Collections.Generic;
using System.Threading.Tasks;
using LibManagementSystem.Infrastructure.DTO;
using LibraryManagementSystem.Domain.Entities;

namespace LibManagementSystem.Infrastructure.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooksWithAuthors();
        Task<BookDto> GetBookWithAuthors(int id);
        
        Task<IEnumerable<BookDto>> GetIssuedBooks();
        Task<IEnumerable<BookDto>> GetAvailableBooks();

        Task<CreateBookDto> CreateBook(CreateBookDto dto);
        Task BorrowBook(CreateIssueDto dto);
        Task ReturnBook(DeleteIssueDto dto);
    }
}