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
    public class ClientQuery : IClientQuery
    {
        private readonly AppDbContext _context;

        public ClientQuery(AppDbContext context)
        {
            _context = context;
        }        

        public async Task<List<Client>> GetListClients()
        {
            var result = await _context.Clients.ToListAsync();

            return result;
        }

        public async Task<bool> ClientExists(int clientId)
        {
            return await _context.Clients.AnyAsync(c => c.ClientID == clientId);
        }
    }
}
