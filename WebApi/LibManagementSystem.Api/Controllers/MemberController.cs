using System.Collections.Generic;
using System.Threading.Tasks;
using LibManagementSystem.Infrastructure.DTO;
using LibManagementSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LibManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetAll()
        {
            var members = await _memberService.GetMembers();
            
            return Ok(members);
        }
        
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<MemberDto>> Add(MemberDto dto)
        {
            await _memberService.CreateMember(dto);
            return Ok(dto);
        }
    }
}