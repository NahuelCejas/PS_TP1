using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project = Application.Response.Project;

namespace Application.UseCase
{
    public class ProjectPatchServices : IProjectPatchServices
    {
        private readonly IProjectQuery _projectQuery;
        private readonly IProjectCommand _projectCommand;
        private readonly ITaskQuery _taskQuery;
        private readonly IInteractionQuery _interactionQuery;
        private readonly IValidatorHandler<TasksRequest> _tasksValidator;
        private readonly IValidatorHandler<InteractionsRequest> _interactionsValidator;


        public ProjectPatchServices(IProjectQuery query, IProjectCommand command, ITaskQuery taskQuery, IInteractionQuery interactionQuery, IValidatorHandler<TasksRequest> tasksValidator, IValidatorHandler<InteractionsRequest> interactionsValidator)
        {
            _projectQuery = query;
            _projectCommand = command; 
            _taskQuery = taskQuery;
            _tasksValidator = tasksValidator;
            _interactionsValidator = interactionsValidator;
            _interactionQuery = interactionQuery;
        }

        public async Task<Interactions> AddInteraction(Guid projectId, InteractionsRequest interactionRequest)
        {
            await _interactionsValidator.Validate(interactionRequest);

            try
            {                
                Domain.Entities.Project project = await _projectQuery.GetProjectById(projectId);                

                if (project == null)
                {
                    throw new NotFoundException("Project not found");
                }                

                var newInteraction = new Interaction
                {                    
                    Notes = interactionRequest.Notes,
                    Date = interactionRequest.Date,
                    ProjectID = projectId,
                    InteractionType = interactionRequest.InteractionType
                };                

                await _projectCommand.AddProjectInteractions(newInteraction);

                project.UpdateDate = DateTime.Now;
                await _projectCommand.UpdateProject(project);

                var interaction = await _interactionQuery.GetInteractionById(newInteraction.InteractionID);

                if (interaction == null)
                {
                    throw new NotFoundException("Interaction not found");
                }

                return new Interactions
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
                };
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
        }

        public async Task<Tasks> AddTask(Guid projectId, TasksRequest taskRequest)
        {
            await _tasksValidator.Validate(taskRequest);

            try 
            {
                Domain.Entities.Project project = await _projectQuery.GetProjectById(projectId);

                if (project == null)
                {
                    throw new NotFoundException("Project not found");
                }

                var newTask = new Job
                {                    
                    Name = taskRequest.Name,
                    DueDate = taskRequest.DueDate,
                    ProjectID = projectId,
                    Status = taskRequest.Status,
                    AssignedTo = taskRequest.User,
                    CreateDate = DateTime.Now
                   
                };

                await _projectCommand.AddProjectTasks(newTask);

                project.UpdateDate = DateTime.Now;
                await _projectCommand.UpdateProject(project);

                var task = await _taskQuery.GetTaskById(newTask.TaskID);

                if (task == null)
                {
                    throw new NotFoundException("Task not found");
                }

                return new Tasks
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
                };               

            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
        }        

    }            
     
}
