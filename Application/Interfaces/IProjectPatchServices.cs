using Application.Request;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProjectPatchServices
    {        
        Task<Interactions> AddInteraction(Guid projectId, InteractionsRequest interaction);
        Task<Tasks> AddTask(Guid projectId, TasksRequest task);
       
    }
}
