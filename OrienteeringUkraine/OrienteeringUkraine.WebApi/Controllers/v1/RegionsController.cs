using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrienteeringUkraine.Application.Regions.Models;
using OrienteeringUkraine.Application.Regions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrienteeringUkraine.WebApi.Controllers.v1
{
    public class RegionsController : ApiController
    {
        public RegionsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<RegionsCollectionModel>> GetAllRegions()
        {
            return Ok(await Mediator.Send(new GetAllRegionsQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<RegionModel>> GetRegionById([FromRoute] GetRegionByIdQuery request)
        {
            var region = await Mediator.Send(request);
            if (region is null)
            {
                return NotFound();
            }
            return Ok(region);
        }

    }
}
