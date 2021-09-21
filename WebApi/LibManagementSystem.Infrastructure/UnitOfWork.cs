using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Repositories;
using LibraryManagementSystem.Infrastructure.Data;
using LibraryManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibManagementSystem.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryManagementDbContext _dbContext;

        public IBookRepository BookRepository { get;  }
        public IAuthorRepository AuthorRepository { get; }
        public IIssuedRepository IssuedRepository { get; }
        public IMemberRepository MemberRepository { get; }

        public UnitOfWork(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
            BookRepository = new BookRepository(_dbContext);
            AuthorRepository = new AuthorRepository(_dbContext);
            IssuedRepository = new IssuedRepository(_dbContext);
            MemberRepository = new MemberRepository(_dbContext);
        }
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task RejectChanges()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        await entry.ReloadAsync();
                        break;
                }
            }
        }

        public async Task Dispose()
        {
            await _dbContext.DisposeAsync();
        }
    }
}