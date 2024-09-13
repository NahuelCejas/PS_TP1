using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class TaskQuery : ITaskQuery
    {
        private readonly AppDbContext _context;

        public TaskQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Job> GetTaskById(Guid id)
        {
            var task = await _context.Jobs
                .Include(t => t.JobStatus)
                .Include(t => t.User)
                .FirstOrDefaultAsync(c => c.TaskID == id);

            return task;
        }
    }
}
