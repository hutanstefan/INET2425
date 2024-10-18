using Application.DTOs;
using Application.Use_Cases.Commands;
using Application.Use_Cases.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagement.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator mediator;

        public BooksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook(CreateBookCommand command)
        {
            return await mediator.Send(command);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BookDto>> GetBookById(Guid id)
        {
            var bookDto = await mediator.Send(new GetBookByIdQuery { Id = id });
            if (bookDto == null)
            {
                return NotFound(new { message = "Book not found" });
            }
            return Ok(bookDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks()
        {
            var books = await mediator.Send(new GetAllBooksQuery());
            return Ok(books);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] UpdateBookCommand command)
        {
            if (command == null)
            {
                return BadRequest(new { message = "Invalid request" });
            }

            command.Id = id;
                
            try
            {
                var updatedBookId = await mediator.Send(command);
                return Ok(updatedBookId); 
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Book not found" }); 
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var deletedBookId = await mediator.Send(new DeleteBookByIdCommand(id));

            if (deletedBookId == Guid.Empty)
            {
                return NotFound(new { message = "Book not found" });
            }

            return Ok(deletedBookId);
        }
    }
}
