using AutoMapper;
using MediatR;
using OrienteeringUkraine.Application.Regions.Models;
using OrienteeringUkraine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrienteeringUkraine.Application.Regions.Queries
{
    public class GetRegionByIdQuery : IRequest<RegionModel>
    {
        public int Id { get; set; }

        public class Hendler : IRequestHandler<GetRegionByIdQuery, RegionModel>
        {
            private readonly OrienteeringUkraineContext dbContext;
            private readonly IMapper mapper;

            public Hendler(OrienteeringUkraineContext dbContext, IMapper mapper)
            {
                this.dbContext = dbContext;
                this.mapper = mapper;
            }
            public async Task<RegionModel> Handle(GetRegionByIdQuery request, CancellationToken cancellationToken)
            {
                var region = await dbContext.Regions.FindAsync(new object[] { request.Id }, cancellationToken);
                return mapper.Map<RegionModel>(region);
            }
        }
    }
}
