using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class ProjectCommand : IProjectCommand
    {
        private readonly AppDbContext _context;

        public ProjectCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertProject(Project project)
        {
            _context.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProject(Project project)
        {
            _context.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task AddProjectInteractions(Interaction interaction)
        {            
            _context.Add(interaction); 
            await _context.SaveChangesAsync();
        }

        
        public async Task AddProjectTasks(Job task)
        {
            _context.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectTasks(Job task)
        {
            _context.Update(task);
            await _context.SaveChangesAsync();
        }
    }
}
