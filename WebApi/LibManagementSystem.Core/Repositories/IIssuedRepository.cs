using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Domain.Repositories
{
    public interface IIssuedRepository : IRepository<Issue>
    {
        Task<IEnumerable<Issue>> GetAllIssuedBooks();
    }
}