using Application.Request;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProjectGetServices
    {
        Task<ProjectDetails> GetProjectById(Guid id);        
        Task<List<Project>> GetProjects(string? name, int? campaign, int? client, int? offset, int? size);
    }
}
