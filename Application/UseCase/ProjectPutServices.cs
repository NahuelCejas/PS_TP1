using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using FluentValidation;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project = Application.Response.Project;

namespace Application.UseCase
{
    public class ProjectPutServices : IProjectPutServices
    {        
        private readonly IProjectCommand _projectCommand;        
        private readonly ITaskQuery _taskQuery;
        private readonly IValidatorHandler<TasksRequest> _tasksValidator;

        public ProjectPutServices(IProjectCommand command, ITaskQuery taskQuery, IValidatorHandler<TasksRequest> tasksValidator)
        {           
            _projectCommand = command;           
            _taskQuery = taskQuery;
            _tasksValidator = tasksValidator;
        }
        
        public async Task<Tasks> UpdateTask(Guid taskId, TasksRequest taskRequest)
        {
            await _tasksValidator.Validate(taskRequest);
            try
            {
                var task = await _taskQuery.GetTaskById(taskId);

                if (task == null)
                {
                    throw new NotFoundException("Task not found");
                }

                task.Name = taskRequest.Name;
                task.DueDate = taskRequest.DueDate;
                task.Status = taskRequest.Status;
                task.AssignedTo = taskRequest.User;
                task.UpdateDate = DateTime.Now;

                await _projectCommand.UpdateProjectTasks(task);

                var updatedTask = await _taskQuery.GetTaskById(taskId);

                if (updatedTask == null)
                {
                    throw new NotFoundException("Task not found");
                }

                return new Tasks
                {
                    Id = updatedTask.TaskID,
                    Name = updatedTask.Name,
                    DueDate = updatedTask.DueDate,
                    ProjectId = updatedTask.ProjectID,
                    Status = new GenericResponse
                    {
                        Id = updatedTask.JobStatus.Id,
                        Name = updatedTask.JobStatus.Name
                    },
                    UserAssigned = new Users
                    {
                        UserID = updatedTask.User.UserID,
                        Name = updatedTask.User.Name,
                        Email = updatedTask.User.Email
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
