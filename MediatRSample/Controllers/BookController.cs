using MediatR;
using MediatRSample.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRSample.Controllers
{
    [ApiController]
    public class BookController:ControllerBase
    {
        private readonly IMediator mediator;

        public BookController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res =await mediator.Send(new GetBookById.Query(id));
            return res == null ? NotFound() : Ok(res);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody ] Commands.AddBook.Command command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
