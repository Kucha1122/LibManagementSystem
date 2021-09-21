
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Infrastructure.Data
{
    public class Seeder
    {
        private readonly LibraryManagementDbContext _dbContext;

        public Seeder(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Books.Any())
                {
                    var books = GetBooks();
                    _dbContext.Books.AddRange(books);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Book> GetBooks()
        {
            var books = new List<Book>()
            {
                new Book()
                {
                    Title = "Czysty kod. Podręcznik dobrego programisty",
                    PublicationYear = new DateTime(2015, 03, 25),
                    Issue = null,
                    Authors = new List<Author>()
                    {
                        new Author()
                        {
                            FirstName = "Robert C.",
                            LastName = "Martin"
                        }
                    }
                },
                new Book()
                {
                    Title = "Linux. Biblia. Wydanie X",
                    PublicationYear = new DateTime(2021, 08, 31),
                    Issue = null,
                    Authors = new List<Author>()
                    {
                        new Author()
                        {
                            FirstName = "Christopher",
                            LastName = "Negus"
                        }
                    }
                },
                new Book()
                {
                    Title = "Pragmatyczny programista. Od czeladnika do mistrza. Wydanie II",
                    PublicationYear = new DateTime(2021, 02, 09),
                    Issue = null,
                    Authors = new List<Author>()
                    {
                        new Author()
                        {
                            FirstName = "David",
                            LastName = "Thomas"
                        },
                        new Author()
                        {
                            FirstName = "Andrew",
                            LastName = "Hunt"
                        }
                    }
                },
                new Book()
                {
                    Title = "Algorytmy. Ilustrowany przewodnik",
                    PublicationYear = new DateTime(2017, 08, 09),
                    Issue = null,
                    Authors = new List<Author>()
                    {
                        new Author()
                        {
                            FirstName = "Aditya",
                            LastName = "Bhargava"
                        }
                    }
                },
                new Book()
                {
                    Title = "Docker dla programistów. Rozwijanie aplikacji i narzędzia ciągłego dostarczania DevOps",
                    PublicationYear = new DateTime(2017, 08, 09),
                    Issue = null,
                    Authors = new List<Author>()
                    {
                        new Author()
                        {
                            FirstName = "Richard",
                            LastName = "Bullington-McGuire"
                        },
                        new Author()
                        {
                            FirstName = "Michael",
                            LastName = "Schwartz"
                        },
                        new Author()
                        {
                            FirstName = "Andrew K.",
                            LastName = "Dennis"
                        }
                    }
                },
                new Book()
                {
                    Title =
                        "Statystyka praktyczna w data science. 50 kluczowych zagadnień w językach R i Python. Wydanie II",
                    PublicationYear = new DateTime(2017, 08, 09),
                    Issue = null,
                    Authors = new List<Author>()
                    {
                        new Author()
                        {
                            FirstName = "Peter",
                            LastName = "Bruce"
                        },
                        new Author()
                        {
                            FirstName = "Andrew",
                            LastName = "Bruce"
                        },
                        new Author()
                        {
                            FirstName = "Peter",
                            LastName = "Gedeck"
                        }
                    }
                }
            };

            return books;
        }
    }
}