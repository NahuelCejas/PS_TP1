
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Application.Validators;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project = Application.Response.Project;

namespace Application.UseCase
{
    public class ProjectPostServices : IProjectPostServices
    {
        private readonly IProjectQuery _projectQuery;
        private readonly IProjectCommand _projectCommand;        
        private readonly IValidatorHandler<ProjectRequest> _projectValidator;


        public ProjectPostServices(IProjectQuery query, IProjectCommand command, IValidatorHandler<ProjectRequest> projectValidator)
        {
            _projectQuery = query;
            _projectCommand = command;
            _projectValidator = projectValidator;                     
        }

        
        public async Task<ProjectDetails> CreateProject(ProjectRequest projectRequest)
        {            
            await _projectValidator.Validate(projectRequest);

            var project = new Domain.Entities.Project
            {
                ProjectName = projectRequest.Name,
                StartDate = projectRequest.Start,
                EndDate = projectRequest.End,
                ClientID = projectRequest.Client,
                CampaignType = projectRequest.CampaignType,
                CreateDate = DateTime.Now                
            };

            await _projectCommand.InsertProject(project);

            Domain.Entities.Project updatedProject = await _projectQuery.GetProjectById(project.ProjectID);            

            return new ProjectDetails
            {
                Data = new Project
                {
                    Id = updatedProject.ProjectID,
                    Name = updatedProject.ProjectName,
                    Start = updatedProject.StartDate,
                    End = updatedProject.EndDate,
                    Client = new Clients
                    {
                        Id = updatedProject.Client.ClientID,
                        Name = updatedProject.Client.Name,
                        Email = updatedProject.Client.Email,
                        Company = updatedProject.Client.Company,
                        Phone = updatedProject.Client.Phone,
                        Address = updatedProject.Client.Address
                    },
                    CampaignType = new GenericResponse
                    {
                        Id = updatedProject.CampaignTypes.Id,
                        Name = updatedProject.CampaignTypes.Name
                    }
                },
                Interactions = new List<Interactions>(),
                Tasks = new List<Tasks>()
            };
        }
       
    }            
     
}
