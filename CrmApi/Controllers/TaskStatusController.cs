using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrmApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        private readonly ITaskStatusServices _taskStatusService;

        public TaskStatusController(ITaskStatusServices taskStatusService)
        {
            _taskStatusService = taskStatusService;
        }

        /// <summary>
        /// Retrieves a list of all task statuses.
        /// </summary> 
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(typeof(GenericResponse[]), 200)]
        public async Task<IActionResult> GetListTaskStatus()
        {
            var result = await _taskStatusService.GetAll();
            return new JsonResult(result) { StatusCode = 200 };

        }
    }
}
