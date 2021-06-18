using MediatR;
using MediatRSample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRSample.Queries
{
    public static class GetBookById
    {
        public record Query(int Id) : IRequest<Response>;
        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly Repository repository;

            public Handler(Repository repository)
            {
                this.repository = repository;
            }
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var response = repository.Books.FirstOrDefault(t => t.Id == request.Id);
                return response!= null ?new Response(response.Id, response.Title, response.Author) : null;
            }
        }

        public record Response(int Id, string Title, string Author);
    }
}
