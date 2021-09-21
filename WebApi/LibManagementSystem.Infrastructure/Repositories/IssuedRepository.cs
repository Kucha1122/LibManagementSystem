using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Repositories;
using LibraryManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class IssuedRepository : Repository<Issue>, IIssuedRepository
    {
        public IssuedRepository(LibraryManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Issue>> GetAllIssuedBooks()
        {
            return await _dbContext.Issues
                .Include(b => b.Book)
                .ToListAsync();
        }
    }
}