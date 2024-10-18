using MediatR;
using System;

namespace Application.Use_Cases.Commands
{
    public class DeleteBookByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; }

        public DeleteBookByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
