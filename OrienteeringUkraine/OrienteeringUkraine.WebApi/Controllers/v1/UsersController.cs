using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrienteeringUkraine.Application.Users.Commands;
using OrienteeringUkraine.Application.Users.Models;
using OrienteeringUkraine.Application.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrienteeringUkraine.WebApi.Controllers.v1
{
    public class UsersController : ApiController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<UsersCollectionModel>> GetAllUsers()
        {
            return Ok(await Mediator.Send(new GetAllUsersQuery()));
        }

        // GET api/<UsersController>/admin
        [HttpGet("{Login}")]
        public async Task<ActionResult<UserModel>> GetUserByLogin([FromRoute] GetUserByLoginQuery request)
        {
            var user = await Mediator.Send(request);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<UserModel>> Post([FromBody] CreateUserCommand request)
        {
            var user = await Mediator.Send(request);
            if (user is null)
            {
                return BadRequest();
            }
            return Created(new Uri($"{Request.Path}/{user.Login}", UriKind.Relative), user);

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
