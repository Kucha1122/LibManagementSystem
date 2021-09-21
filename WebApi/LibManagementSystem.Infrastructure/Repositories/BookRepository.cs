using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Repositories;
using LibraryManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Book> GetByTitle(string title)
        {
            return await FirstOrDefault(b => b.Title == title);
        }

        public async Task<IEnumerable<Book>> GetBooksWithAuthors()
        {
            return await _dbContext.Books
                .Include(b => b.Authors)
                .Include(i => i.Issue)
                .ThenInclude(xi => xi.Member)
                .ToListAsync();
        }

        public async Task<Book> GetBookWithAuthors(int id)
        {
            return await _dbContext.Books
                .Where(b => b.Id == id)
                .Include(x => x.Authors)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetIssuedBooks()
        {
            return await _dbContext.Books
                .Include(b => b.Authors)
                .Include(i => i.Issue)
                .ThenInclude(xi => xi.Member)
                .Where(x => x.Issue != null)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAvailableBooks()
        {
            return await _dbContext.Books
                .Include(b => b.Authors)
                .Include(i => i.Issue)
                .Where(x => x.Issue == null)
                .ToListAsync();
        }
    }
}