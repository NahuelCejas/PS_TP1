using Application.Interfaces;
using Application.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Application.Validators
{
    public class ProjectRequestValidator : AbstractValidator<ProjectRequest>
    {
        private readonly IProjectQuery _projectQuery;
        private readonly IClientQuery _clientQuery;

        public ProjectRequestValidator(IProjectQuery projectQuery, IClientQuery clientQuery)
        {
            _projectQuery = projectQuery;
            _clientQuery = clientQuery;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MustAsync(BeUniqueName).WithMessage("A project with the same name already exists.");

            RuleFor(x => x.Start)
                .NotEmpty()
                .WithMessage("Start date is required")
                .GreaterThan(DateTime.Now)
                .WithMessage("Start date must be in the future.");


            RuleFor(x => x.End)
                .NotEmpty()
                .WithMessage("End date is required.") 
                .GreaterThan(DateTime.Now)
                .WithMessage("End date must be in the future.");

            RuleFor(x => x)
                .Must(x => BeValidEndDate(x.Start, x.End))
                .WithMessage("End date must be greater than Start date.");

            RuleFor(x => x.Client)
                .MustAsync(ClientExists).WithMessage("Client with the provided ID does not exist.");

            RuleFor(x => x.CampaignType)
                .NotEmpty()
                .WithMessage("CampaignType is required.")
                .InclusiveBetween(1, 4)
                .WithMessage("CampaignType must be a number between 1 and 4.");            
        }

        // Check that Project Name is unique
        private async Task<bool> BeUniqueName(string name, CancellationToken token)
        {
            var existingProject = await _projectQuery.GetProjectByName(name);
            return existingProject == null;  
        }

        // Check that End is not before Start
        private static bool BeValidEndDate(DateTime? start, DateTime? end)
        {
            return end > start; 
        }

        // Check that Client exists
        private async Task<bool> ClientExists(int clientId, CancellationToken cancellationToken)
        {
            
            return await _clientQuery.ClientExists(clientId);
        }
        
    }
}
