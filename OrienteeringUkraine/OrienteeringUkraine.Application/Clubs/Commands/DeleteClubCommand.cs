using MediatR;
using OrienteeringUkraine.Application.Infrastructure.Models;
using OrienteeringUkraine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrienteeringUkraine.Application.Clubs.Commands
{
    public class DeleteClubCommand : IRequest<DeleteModel>
    {
        public int Id { get; set; }

        public class Hendler : IRequestHandler<DeleteClubCommand, DeleteModel>
        {
            private readonly OrienteeringUkraineContext dbContext;

            public Hendler(OrienteeringUkraineContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<DeleteModel> Handle(DeleteClubCommand request, CancellationToken cancellationToken)
            {
                var clubInBd = dbContext.Clubs.Find(request.Id);
                if (clubInBd is null)
                {
                    return new DeleteModel { IsDeletionSuccessful = false };
                }
                dbContext.Clubs.Remove(clubInBd);
                await dbContext.SaveChangesAsync(cancellationToken);
                return new DeleteModel { IsDeletionSuccessful = true };
            }
        }
    }
}
