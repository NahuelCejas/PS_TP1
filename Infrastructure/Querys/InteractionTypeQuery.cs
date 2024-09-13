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
    public class InteractionTypeQuery : IInteractionTypeQuery
    {
        private readonly AppDbContext _context;

        public InteractionTypeQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<InteractionType>> GetListInteractionTypes()
        {
            var interactionTypes = await _context.InteractionTypes.ToListAsync();            

            return interactionTypes;
        }

        public async Task<InteractionType> GetInteractionTypeById(int id)
        {
            var interactionType = await _context.InteractionTypes.FirstOrDefaultAsync(c => c.Id == id);

            return interactionType;
        }
    }
}
