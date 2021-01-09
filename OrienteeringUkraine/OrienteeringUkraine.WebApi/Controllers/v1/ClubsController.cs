using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrienteeringUkraine.Application.Clubs.Commands;
using OrienteeringUkraine.Application.Clubs.Models;
using OrienteeringUkraine.Application.Clubs.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrienteeringUkraine.WebApi.Controllers.v1
{
    public class ClubsController : ApiController
    {
        public ClubsController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        public async Task<ActionResult<ClubsCollectionModel>> GetAllClubs()
        {
            return Ok(await Mediator.Send(new GetAllClubsQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ClubModel>> GetRegionById([FromRoute] GetClubByIdQuery request)
        {
            var club = await Mediator.Send(request);
            if (club is null)
            {
                return NotFound();
            }
            return Ok(club);
            
        }
        [HttpPost]
        public async Task<ActionResult<ClubModel>> CreateClub([FromBody] CreateClubCommand request)
        {
            var club = await Mediator.Send(request);
            if (club is null)
            {
                return BadRequest();
            }
            return Created(new Uri($"{Request.Path}/{club.Id}", UriKind.Relative), club);

        }
        [HttpPut]
        public async Task<ActionResult<ClubModel>> Put(UpdateClubCommand request)
        {
            var club = await Mediator.Send(request);
            if (club is null)
            {
                return NotFound();
            }
            return Ok(club);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteClub([FromRoute] DeleteClubCommand request)
        {
            var status = (await Mediator.Send(request)).IsDeletionSuccessful;
            return status ? NoContent() : NotFound();
        }
    }
}
