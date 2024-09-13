using Application.Interfaces;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class InteractionTypeServices : IInteractionTypeServices
    {
        private readonly IInteractionTypeQuery _interactionTypeQuery;

        public InteractionTypeServices(IInteractionTypeQuery query)
        {
            _interactionTypeQuery = query;
        }

        public async Task<List<GenericResponse>> GetAll()
        {
            var interactionTypes = await _interactionTypeQuery.GetListInteractionTypes();

            var genericResponses = interactionTypes.Select(c => new GenericResponse
            {
                Id = c.Id,
                Name = c.Name

            }).ToList();

            return genericResponses;
        }
        
    }
}
