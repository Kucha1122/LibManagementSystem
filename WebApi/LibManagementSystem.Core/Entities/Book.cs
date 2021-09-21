using System;
using System.Collections;
using System.Collections.Generic;

namespace LibraryManagementSystem.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? PublicationYear { get; set; }
        public virtual Issue Issue { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

    }
}