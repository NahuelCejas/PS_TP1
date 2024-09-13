using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProjectCommand
    {
        Task InsertProject(Project project);                
        Task AddProjectInteractions(Interaction interaction);
        Task UpdateProjectTasks(Job task);
        Task AddProjectTasks(Job task);
        Task UpdateProject(Project project);
    }
}
