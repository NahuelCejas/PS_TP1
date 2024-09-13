using Application.Interfaces;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class TaskStatusServices : ITaskStatusServices
    {
        private readonly ITaskStatusQuery _taskStatusQuery;

        public TaskStatusServices(ITaskStatusQuery query)
        {
            _taskStatusQuery = query;
        }

        public async Task<List<GenericResponse>> GetAll()
        {
            var taskStatus = await _taskStatusQuery.GetListTaskStatus();

            var result = taskStatus.Select(x => new GenericResponse
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return result;
        }
    }
}
