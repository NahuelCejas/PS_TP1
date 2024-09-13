using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project = Application.Response.Project;

namespace Application.UseCase
{
    public class ProjectGetServices : IProjectGetServices
    {
        private readonly IProjectQuery _projectQuery;       

        public ProjectGetServices(IProjectQuery query)
        {
            _projectQuery = query;           
        }               

       
        public async Task<ProjectDetails> GetProjectById(Guid id)
        {
            try
            {
                Domain.Entities.Project project = await _projectQuery.GetProjectById(id);                

                if (project == null)
                {
                    throw new NotFoundException("Project not found");
                }

                var data = new Project
                {
                    Id = project.ProjectID,
                    Name = project.ProjectName,
                    Start = project.StartDate,
                    End = project.EndDate,
                    Client = new Clients
                    {
                        Id = project.Client.ClientID,
                        Name = project.Client.Name,
                        Email = project.Client.Email,
                        Company = project.Client.Company,
                        Phone = project.Client.Phone,
                        Address = project.Client.Address
                    },
                    CampaignType = new GenericResponse
                    {
                        Id = project.CampaignTypes.Id,
                        Name = project.CampaignTypes.Name
                    }
                };

                var interactions = project.Interactions.Select(interaction => new Interactions
                {
                    Id = interaction.InteractionID,
                    Notes = interaction.Notes,
                    Date = interaction.Date,
                    ProjectId = interaction.ProjectID,
                    InteractionType = new GenericResponse
                    {
                        Id = interaction.InteractionTypes.Id,
                        Name = interaction.InteractionTypes.Name
                    }
                }).ToList();

                var tasks = project.Jobs.Select(task => new Tasks
                {
                    Id = task.TaskID,
                    Name = task.Name,
                    DueDate = task.DueDate,
                    ProjectId = task.ProjectID,
                    Status = new GenericResponse
                    {
                        Id = task.JobStatus.Id,
                        Name = task.JobStatus.Name
                    },
                    UserAssigned = new Users
                    {
                        UserID = task.User.UserID,
                        Name = task.User.Name,
                        Email = task.User.Email
                    }
                }).ToList();

                return await Task.FromResult(new ProjectDetails
                {
                    Data = data,
                    Interactions = interactions,
                    Tasks = tasks
                });
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
        }     


        public async Task<List<Project>> GetProjects(string? name, int? campaign, int? client, int? offset, int? size)
        {
            var projects = await _projectQuery.GetProjects(name, campaign, client, offset, size);

            var responseProjects = new List<Project>();

            foreach (var project in projects)
            {
                var responseProject = new Project
                {
                    Id = project.ProjectID,
                    Name = project.ProjectName,
                    Start = project.StartDate,
                    End = project.EndDate,
                    Client = new Clients
                    {
                        Id = project.Client.ClientID,
                        Name = project.Client.Name,
                        Email = project.Client.Email,
                        Company = project.Client.Company,
                        Phone = project.Client.Phone,
                        Address = project.Client.Address
                    },
                    CampaignType = new GenericResponse
                    {
                        Id = project.CampaignTypes.Id,
                        Name = project.CampaignTypes.Name
                    }
                };

                responseProjects.Add(responseProject);
            }

            return responseProjects;
        }
        
    }            
     
}
