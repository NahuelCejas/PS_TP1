﻿using Application.Request;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProjectPutServices
    {        
        Task<Tasks> UpdateTask(Guid taskId, TasksRequest task);       
    }
}
