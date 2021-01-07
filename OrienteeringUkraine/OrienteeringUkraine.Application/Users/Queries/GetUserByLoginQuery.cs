
using AutoMapper;
using FluentValidation;
using MediatR;
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
    public class GetUserByLoginQuery : IRequest<UserModel>
    {
        public string Login { get; set; }

        public class Validator : AbstractValidator<GetUserByLoginQuery>
        {
            public Validator()
            {
                RuleFor(x => x.Login).NotEmpty();
            }
        }

        public class Hendler : IRequestHandler<GetUserByLoginQuery, UserModel>
        {
            private readonly OrienteeringUkraineContext dbContext;
            private readonly IMapper mapper;
            public Hendler(OrienteeringUkraineContext dbContext, IMapper mapper)
            {
                this.dbContext = dbContext;
                this.mapper = mapper;
            }
            public async Task<UserModel> Handle(GetUserByLoginQuery request, CancellationToken cancellationToken)
            {
                var user = await dbContext.Users.FindAsync(new[] { request.Login }, cancellationToken);
                return mapper.Map<UserModel>(user);
            }
        }
    }
}
                            