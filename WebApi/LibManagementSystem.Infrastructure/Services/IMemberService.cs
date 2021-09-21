using System.Collections.Generic;
using System.Threading.Tasks;
using LibManagementSystem.Infrastructure.DTO;

namespace LibManagementSystem.Infrastructure.Services
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberDto>> GetMembers();
        
        Task<MemberDto> CreateMember(MemberDto dto);
    }
}