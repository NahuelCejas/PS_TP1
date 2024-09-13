using Application.Interfaces;
using Application.Response;
using Application.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrmApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InteractionTypesController : ControllerBase
    {
        private readonly IInteractionTypeServices _interactionTypeServices;

        public InteractionTypesController(IInteractionTypeServices interactionTypeServices)
        {
            _interactionTypeServices = interactionTypeServices;
        }

        /// <summary>
        /// Retrieves a list of all interaction types.
        /// </summary> 
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(typeof(GenericResponse[]), 200)]
        public async Task<IActionResult> GetListInteractionTypes()
        {
            var result = await _interactionTypeServices.GetAll();
            return new JsonResult(result) { StatusCode = 200 };

        }
    }
}
