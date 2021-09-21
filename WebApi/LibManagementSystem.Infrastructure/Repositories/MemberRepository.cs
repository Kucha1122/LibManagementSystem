using System.Threading.Tasks;
using AutoMapper.Internal;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Repositories;
using LibraryManagementSystem.Infrastructure.Data;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(LibraryManagementDbContext dbContext) : base(dbContext)
        {
        }
        
    }
}