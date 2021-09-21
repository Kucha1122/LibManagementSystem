using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Domain.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<Author>> GetAllWithBooks();
        Task<Author> GetAuthorWithBooks(int id);
    }
}