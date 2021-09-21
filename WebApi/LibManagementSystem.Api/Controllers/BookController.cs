using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibManagementSystem.Infrastructure.DTO;
using LibManagementSystem.Infrastructure.Services;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LibManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<ActionResult<BookDto>> Get([FromQuery]int id)
        {
            var book = await _bookService.GetBookWithAuthors(id);

            return Ok(book);
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
        {
            var books = await _bookService.GetBooksWithAuthors();
            
            return Ok(books);
        }
        
        [HttpGet]
        [Route("available")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAvaiable()
        {
            var books = await _bookService.GetAvailableBooks();
            
            return Ok(books);
        }
        
        [HttpGet]
        [Route("issued")]
        public async Task<ActionResult<IEnumerable<IssueDto>>> GetIssued()
        {
            var books = await _bookService.GetIssuedBooks();
            
            return Ok(books);
        }

        [HttpPost]
        [Route("borrow")]
        public async Task<ActionResult> BorrowBook(CreateIssueDto dto)
        {
            await _bookService.BorrowBook(dto);
            return Ok(dto);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<BookDto>> Add(CreateBookDto dto)
        {
            await _bookService.CreateBook(dto);
            return Ok(dto);
        }

        [HttpPost]
        [Route("return")]
        public async Task<ActionResult> Return(DeleteIssueDto dto)
        {
            await _bookService.ReturnBook(dto);
            return Ok();
        }
    }
}