using AutoMapper;
using FluentValidation;
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

namespace OrienteeringUkraine.Application.Clubs.Commands
{
    public class CreateClubCommand : IRequest<ClubModel>
    {
        public string Name { get; set; }

        public class Validator : AbstractValidator<CreateClubCommand>
        {
            public Validator(OrienteeringUkraineContext dbContext)
            {
                RuleFor(c => c.Name).NotNull()
                                    .Must(name => dbContext.Clubs.FirstOrDefault(c => c.Name == name) is null)
                                    .WithErrorCode("IsTakenValidator");
            }
        }

        public class Hendler : IRequestHandler<CreateClubCommand, ClubModel>
        {
            private readonly OrienteeringUkraineContext dbContext;
            private readonly IMapper mapper;

            public Hendler(OrienteeringUkraineContext dbContext, IMapper mapper)
            {
                this.dbContext = dbContext;
                this.mapper = mapper;
            }
            public async Task<ClubModel> Handle(CreateClubCommand request, CancellationToken cancellationToken)
            {
                var club = mapper.Map<Club>(request);
                await dbContext.Clubs.AddAsync(club, cancellationToken);
                await dbContext.SaveChangesAsync(cancellationToken);
                return mapper.Map<ClubModel>(club);

            }
        }

    }
}
