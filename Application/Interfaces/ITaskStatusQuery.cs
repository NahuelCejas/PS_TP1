using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITaskStatusQuery
    {
        Task<List<JobStatus>> GetListTaskStatus();
        Task<JobStatus> GetTaskStatusById(int id);
    }
}
