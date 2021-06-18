using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRSample.Commands
{
    public static class AddBook
    {
        //Command /query
        public record Command(string Title, string Author):IRequest<int>;
        //Handler
        public class Handler : IRequestHandler<Command, int>
        {
            private readonly Repository repository;

            public Handler(Repository repository)
            {
                this.repository = repository;
            }
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var id = repository.Books.Max(t => t.Id) + 1;
                repository.Books.Add(new Domain.Book { Id =id, Title = request.Title, Author = request.Author });
                return id;
            }
        }
    }
}
