using System;
using System.Dynamic;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities.Commands;

public class DeleteActivity
{
   public class Command : IRequest
   {
        public required string Id {get; set;}
   }

   public class Handler(AppDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
           var activity = await context.Activities.FindAsync([request.Id] , cancellationToken) ?? throw new Exception("Activity not found");

            // Remove the entity
            context.Activities.Remove(activity);

            // Save changes
            await context.SaveChangesAsync(cancellationToken);

        }
    }
}