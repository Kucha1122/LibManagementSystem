using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibManagementSystem.Infrastructure.DTO;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Repositories;

namespace LibManagementSystem.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetBooksWithAuthors()
        {
            var books = await _unitOfWork.BookRepository.GetBooksWithAuthors();

            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto> GetBookWithAuthors(int id)
        {
            var book = await _unitOfWork.BookRepository.GetBookWithAuthors(id);

            return _mapper.Map<BookDto>(book);
        }

        public async Task<IEnumerable<BookDto>> GetIssuedBooks()
        {
            var books = await _unitOfWork.BookRepository.GetIssuedBooks();
            
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<IEnumerable<BookDto>> GetAvailableBooks()
        {
            var books = await _unitOfWork.BookRepository.GetAvailableBooks();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<CreateBookDto> CreateBook(CreateBookDto dto)
        {
            var book = await _unitOfWork.BookRepository.FirstOrDefault(x => x.Title == dto.Title && x.PublicationYear == dto.PublicationYear);

            if (book is not null)
            {
                throw new Exception("That book already exists.");
            }

            await _unitOfWork.BookRepository.AddAsync(_mapper.Map<Book>(dto));
            await _unitOfWork.Commit();

            return dto;
        }

        public async Task BorrowBook(CreateIssueDto dto)
        {
            var member = await _unitOfWork.MemberRepository
                .FirstOrDefault(x => x.FirstName == dto.FirstName && x.LastName == dto.LastName && x.PhoneNumber == dto.Phone);
            if (member is not null)
            {
                var issue = new Issue
                {
                    MemberId = member.Id,
                    IssueDate = DateTime.UtcNow,
                    ExpireDate = DateTime.UtcNow.AddDays(dto.Days),
                    BookId = dto.BookId
                };
                await _unitOfWork.IssuedRepository.AddAsync(issue);
            }
            else
            {
                member = new Member {FirstName = dto.FirstName, LastName = dto.LastName, PhoneNumber = dto.Phone};
                await _unitOfWork.MemberRepository.AddAsync(member);

                var issue = new Issue
                {
                    MemberId = member.Id,
                    IssueDate = DateTime.UtcNow.Date,
                    ExpireDate = DateTime.UtcNow.AddDays(dto.Days),
                    BookId = dto.BookId
                };
                await _unitOfWork.IssuedRepository.AddAsync(issue);
            }
            await _unitOfWork.Commit();
        }

        public async Task ReturnBook(DeleteIssueDto dto)
        {
            var issue = await _unitOfWork.IssuedRepository
                .FirstOrDefault(x => x.Member.FirstName == dto.FirstName &&
                                     x.Member.LastName == dto.LastName &&
                                     x.Member.PhoneNumber == dto.Phone &&
                                     x.BookId == dto.BookId);

            if (issue is null)
                throw new Exception("Issue with this bookId or member does not exist.");
            
            await _unitOfWork.IssuedRepository.RemoveAsync(issue);
        }
    }
}