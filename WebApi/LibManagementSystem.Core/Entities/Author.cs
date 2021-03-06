using System.Collections;
using System.Collections.Generic;

namespace LibraryManagementSystem.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        
    }
}