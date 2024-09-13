using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IInteractionTypeQuery
    {
        Task<List<InteractionType>> GetListInteractionTypes();
        Task<InteractionType> GetInteractionTypeById(int id);
    }
}
