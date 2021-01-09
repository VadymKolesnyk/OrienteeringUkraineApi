using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class GetAllRegionsQuery : IRequest<RegionsCollectionModel>
    {

        public class Hendler : IRequestHandler<GetAllRegionsQuery, RegionsCollectionModel>
        {
            private readonly OrienteeringUkraineContext dbContext;
            private readonly IMapper mapper;

            public Hendler(OrienteeringUkraineContext dbContext, IMapper mapper)
            {
                this.dbContext = dbContext;
                this.mapper = mapper;
            }
            public async Task<RegionsCollectionModel> Handle(GetAllRegionsQuery request, CancellationToken cancellationToken)
            {
                var regions = await dbContext.Regions.ToListAsync(cancellationToken);
                var regionsModel = mapper.Map<IEnumerable<RegionModel>>(regions);
                return new RegionsCollectionModel { Items = regionsModel };
            }
        }
    }
}
