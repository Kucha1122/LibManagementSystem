using System;
using System.Collections.Generic;
using LibraryManagementSystem.Domain.Entities;

namespace LibManagementSystem.Infrastructure.DTO
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public DateTime? PublicationYear { get; set; }
        
        public  List<AuthorDto> Authors { get; set; }
    }
}