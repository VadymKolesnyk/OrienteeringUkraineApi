using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrienteeringUkraine.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        public ApiController(IMediator mediator)
        {
            Mediator = mediator;
        }

        public IMediator Mediator { get; }
    }
}
