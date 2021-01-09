using AutoMapper;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
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
    public class UpdateClubCommand : IRequest<ClubModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class Validator : AbstractValidator<UpdateClubCommand>
        {
            public Validator(OrienteeringUkraineContext dbContext)
            {
                RuleFor(x => x.Id).NotNull();

                RuleFor(c => c.Name).NotNull()
                    .Must(name => dbContext.Clubs.FirstOrDefault(c => c.Name == name) is null)
                    .WithErrorCode("IsTakenValidator");
            }
        }

        public class Hendler : IRequestHandler<UpdateClubCommand, ClubModel>
        {
            private readonly OrienteeringUkraineContext dbContext;
            private readonly IMapper mapper;

            public Hendler(OrienteeringUkraineContext dbContext, IMapper mapper)
            {
                this.dbContext = dbContext;
                this.mapper = mapper;
            }
            public async Task<ClubModel> Handle(UpdateClubCommand request, CancellationToken cancellationToken)
            {
                var club = mapper.Map<Club>(request);
                var clubInBd = dbContext.Clubs.Find(request.Id);
                if (clubInBd is null)
                {
                    return null;
                }
                dbContext.Clubs.Remove(clubInBd);
                dbContext.Clubs.Add(club);
                await dbContext.SaveChangesAsync(cancellationToken);
                return mapper.Map<ClubModel>(club);
            }
        }
    }
}
