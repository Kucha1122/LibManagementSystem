using System.Collections;
using System.Collections.Generic;

namespace LibraryManagementSystem.Domain.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }

    }
}