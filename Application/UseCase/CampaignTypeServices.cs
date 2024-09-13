using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Response;
using Application.Interfaces;
using Domain.Entities;



namespace Application.UseCase
{
    public class CampaignTypeServices : ICampaignTypeServices
    {
        private readonly ICampaignTypeQuery _campaignTypeQuery;

        public CampaignTypeServices(ICampaignTypeQuery query)
        {
            _campaignTypeQuery = query;
        }

        public async Task<List<GenericResponse>> GetAll()
        {
            var campaignTypes = await _campaignTypeQuery.GetListCampaignTypes();

            var genericResponses = campaignTypes.Select(c => new GenericResponse
            {
                Id = c.Id,
                Name = c.Name

            }).ToList();

            return genericResponses;
        }
        
    }
}
