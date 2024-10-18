using Application.Use_Cases.Commands;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Use_Cases.CommandHandlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Guid>
    {
        private readonly IBookRepository bookRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<Guid> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var existingBook = await bookRepository.GetByIdAsync(request.Id);
            if (existingBook == null)
            {
                throw new KeyNotFoundException("Book not found");
            }

            existingBook.Title = request.Title;
            existingBook.Author = request.Author;
            existingBook.ISBN = request.ISBN;
            existingBook.PublicationDate = request.PublicationDate;

            await bookRepository.UpdateAsync(existingBook);

            return existingBook.Id; 
        }
    }
}
