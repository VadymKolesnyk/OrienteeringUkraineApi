using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrienteeringUkraine.Application.Users.Models;
using OrienteeringUkraine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrienteeringUkraine.Application.Users.Queries
{
    public class GetAllUsersQuery : IRequest<UsersCollectionModel>
    {
        public class Handler : IRequestHandler<GetAllUsersQuery, UsersCollectionModel>
        {
            private readonly OrienteeringUkraineContext dbContext;
            private readonly IMapper mapper;

            public Handler(OrienteeringUkraineContext dbContext, IMapper mapper)
            {
                this.dbContext = dbContext;
                this.mapper = mapper;
            }

            public async Task<UsersCollectionModel> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                var allUsers = await dbContext.Users
                    .ToListAsync(cancellationToken);

                var mappedUsers = mapper.Map<IEnumerable<UserModel>>(allUsers);

                return new UsersCollectionModel { Items = mappedUsers };
            }
        }
    }
}
