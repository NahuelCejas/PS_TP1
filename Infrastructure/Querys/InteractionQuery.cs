using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class InteractionQuery : IInteractionQuery
    {
        private readonly AppDbContext _context;

        public InteractionQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Interaction> GetInteractionById(Guid id)
        {
            var interaction = await _context.Interactions                
                .Include(i => i.InteractionTypes)
                .FirstOrDefaultAsync(c => c.InteractionID == id);

            return interaction;
        }
    }
}
