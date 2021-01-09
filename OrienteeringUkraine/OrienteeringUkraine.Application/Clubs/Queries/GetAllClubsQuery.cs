using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrienteeringUkraine.Application.Clubs.Models;
using OrienteeringUkraine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrienteeringUkraine.Application.Clubs.Queries
{
    public class GetAllClubsQuery : IRequest<ClubsCollectionModel>
    {

        public class Hendler : IRequestHandler<GetAllClubsQuery, ClubsCollectionModel>
        {
            private readonly OrienteeringUkraineContext dbContext;
            private readonly IMapper mapper;

            public Hendler(OrienteeringUkraineContext dbContext, IMapper mapper)
            {
                this.dbContext = dbContext;
                this.mapper = mapper;
            }
            public async Task<ClubsCollectionModel> Handle(GetAllClubsQuery request, CancellationToken cancellationToken)
            {
                var clubs = await dbContext.Clubs.ToListAsync(cancellationToken);
                var clubsModel = mapper.Map<IEnumerable<ClubModel>>(clubs);
                return new ClubsCollectionModel { Items = clubsModel };
            }
        }
    }
}
