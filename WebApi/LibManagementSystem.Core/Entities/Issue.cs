using System;

namespace LibraryManagementSystem.Domain.Entities
{
    public class Issue
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        
        public virtual Member Member { get; set; }
        public int MemberId { get; set; }
        public virtual Book Book { get; set; }
        public int BookId { get; set; }

    }
}