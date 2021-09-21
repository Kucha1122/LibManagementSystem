using System;
using LibraryManagementSystem.Domain.Entities;

namespace LibManagementSystem.Infrastructure.DTO
{
    public class IssueDto
    {
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public MemberDto Member { get; set; }
    }
}