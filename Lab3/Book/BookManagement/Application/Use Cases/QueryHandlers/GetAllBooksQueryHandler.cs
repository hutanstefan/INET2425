using Application.DTOs;
using Application.Use_Cases.Queries;
using Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Use_Cases.QueryHandlers
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IBookRepository bookRepository;

        public GetAllBooksQueryHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await bookRepository.GetAllAsync();
            return books.Select(book => new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                PublicationDate = book.PublicationDate
            });
        }
    }
}
