using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Infrastructure.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Querys
{
    public class CampaignTypeQuery : ICampaignTypeQuery
    {
        private readonly AppDbContext _context;

        public CampaignTypeQuery(AppDbContext context)
        {
            _context = context;
        }

        public Task<CampaignType> GetCampaignTypeById(int id)
        {
            var campaignType = _context.CampaignTypes.FirstOrDefaultAsync(c => c.Id == id);

            return campaignType;
        }

        public async Task<List<CampaignType>> GetListCampaignTypes()
        {
            var campaignTypes = await _context.CampaignTypes.ToListAsync();

            return campaignTypes;
        }
    }
}
