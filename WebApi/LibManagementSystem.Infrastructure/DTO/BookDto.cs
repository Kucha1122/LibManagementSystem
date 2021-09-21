using System;
using System.Collections.Generic;
using LibraryManagementSystem.Domain.Entities;

namespace LibManagementSystem.Infrastructure.DTO
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? PublicationYear { get; set; }
        public IssueDto Issue { get; set; }

        public  List<AuthorDto> Authors { get; set; }
    }
}