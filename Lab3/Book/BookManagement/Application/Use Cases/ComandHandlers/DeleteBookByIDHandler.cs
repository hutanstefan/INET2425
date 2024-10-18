using Application.Use_Cases.Commands;
using Domain.Repositories;
using MediatR;

public class DeleteBookByIdHandler : IRequestHandler<DeleteBookByIdCommand, Guid>
{
    private readonly IBookRepository bookRepository;

    public DeleteBookByIdHandler(IBookRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    public async Task<Guid> Handle(DeleteBookByIdCommand request, CancellationToken cancellationToken)
    {
        var deletedBookId = await bookRepository.DeleteAsync(request.Id);
        return deletedBookId; 
    }
}
