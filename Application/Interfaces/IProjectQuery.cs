using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProjectQuery
    {
        Task<Project> GetProjectById(Guid projectId);
        Task<IEnumerable<Project>> GetProjects(string? name, int? campaign, int? client, int? offset, int? size); 
        Task<Project> GetProjectByName(string name);
    }
}
