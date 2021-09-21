using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Repositories;

namespace LibManagementSystem.Infrastructure
{
    public interface IUnitOfWork
    {    
        
        IBookRepository BookRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IIssuedRepository IssuedRepository { get; }
        IMemberRepository MemberRepository { get; }
        
        Task Commit(); 
        Task RejectChanges();
        Task Dispose();
    }
}