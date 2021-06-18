using MediatRSample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRSample
{
    public class Repository
    {
        public List<Book> Books { set; get; } = new List<Book>
        {
            new Book { Author = "Eric Evance", Id = 1, Title = "Domain driven disgen" },
            new Book { Author = "morsa", Title = "test", Id = 2 }
        };
    }
}
