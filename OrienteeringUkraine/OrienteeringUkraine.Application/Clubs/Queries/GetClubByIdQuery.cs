using AutoMapper;
using MediatR;
using OrienteeringUkraine.Application.Clubs.Models;
using OrienteeringUkraine.Data;
using OrienteeringUkraine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrienteeringUkraine.Application.Clubs.Queries
{
    public class GetClubByIdQuery : IRequest<ClubModel>
    {
        public int Id { get; set; }

        public class Hendler : IRequestHandler<GetClubByIdQuery, ClubModel>
        {
            private readonly OrienteeringUkraineContext dbContext;
            private readonly IMapper mapper;

            public Hendler(OrienteeringUkraineContext dbContext, IMapper mapper)
            {
                this.dbContext = dbContext;
                this.mapper = mapper;
            }
            public async Task<ClubModel> Handle(GetClubByIdQuery request, CancellationToken cancellationToken)
            {
                var club = await dbContext.Clubs.FindAsync(new object[] { request.Id }, cancellationToken);
                return mapper.Map<ClubModel>(club);
            }
        }
    }
}