﻿using MediatR;
using System;

namespace Application.Use_Cases.Commands
{
    public class UpdateBookCommand : IRequest<Guid>
    {
        public Guid Id { get; set; } 
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
