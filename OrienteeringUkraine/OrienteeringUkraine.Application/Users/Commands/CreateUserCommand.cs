using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrienteeringUkraine.Application.Users.Models;
using OrienteeringUkraine.Data;
using OrienteeringUkraine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrienteeringUkraine.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<UserModel>
    { 
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Sex { get; set; }
        public int RegionId { get; set; }
        public int? ClubId { get; set; }

        public class Validator : AbstractValidator<CreateUserCommand>
        {
            public Validator(OrienteeringUkraineContext dbContext)
            {
                RuleFor(x => x.Login).NotEmpty()
                                     .Must(login => dbContext.Users.Find(login) is null)
                                     .WithErrorCode("IsTakenValidator");

                RuleFor(x => x.Password).NotEmpty()
                                        .MinimumLength(6);
                RuleFor(x => x.ConfirmPassword).Equal(x => x.Password)
                                               .WithErrorCode("ConfirmPasswordValidator");

                RuleFor(x => x.Name).MaximumLength(50);
                RuleFor(x => x.Surname).NotEmpty()
                                       .MaximumLength(50);

                RuleFor(x => x.RegionId).Must(id => dbContext.Regions.Find(id) is not null)
                                        .WithErrorCode("NotExistsValidator");

                RuleFor(x => x.ClubId).Must(id => !id.HasValue || dbContext.Clubs.Find(id.Value) is not null)
                                      .WithErrorCode("NotExistsValidator");
                
            }
        }
        public class Hendler : IRequestHandler<CreateUserCommand, UserModel>
        {
            private readonly OrienteeringUkraineContext dbContext;
            private readonly IMapper mapper;

            public Hendler(IMapper mapper, OrienteeringUkraineContext dbContext)
            {
                this.mapper = mapper;
                this.dbContext = dbContext;
            }

            public async Task<UserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var user = mapper.Map<User>(request);

                user.Role = await dbContext.Roles.FirstAsync(r => r.Name == "sportsman", cancellationToken);

                await dbContext.Users.AddAsync(user, cancellationToken);

                await dbContext.SaveChangesAsync(cancellationToken);

                return mapper.Map<UserModel>(user);
            }
        }
    }
}
