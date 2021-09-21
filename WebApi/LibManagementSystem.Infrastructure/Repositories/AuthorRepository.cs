using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Repositories;
using LibraryManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Author>> GetAllWithBooks()
        {
            return await _dbContext.Authors
                .Include(b => b.Books)
                .ToListAsync();
        }

        public async Task<Author> GetAuthorWithBooks(int id)
        {
            return await _dbContext.Authors
                .Where(a => a.Id == id)
                .Include(b => b.Books)
                .SingleOrDefaultAsync();
        }
    }
}