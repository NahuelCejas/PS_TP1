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
    public class TaskStatusQuery : ITaskStatusQuery
    {
        private readonly AppDbContext _context;

        public TaskStatusQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobStatus>> GetListTaskStatus()
        {
            var taskStatus = await _context.JobStatus.ToListAsync();

            return taskStatus;
        }

        public async Task<JobStatus> GetTaskStatusById(int id)
        {
            var taskStatus = await _context.JobStatus.FirstOrDefaultAsync(c => c.Id == id);

            return taskStatus;
        }
    }
}
