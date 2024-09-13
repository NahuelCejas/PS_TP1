using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Application.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrmApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices _clientService;

        public ClientController(IClientServices clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Retrieves a list of all clients.
        /// </summary> 
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(typeof(Clients[]), 200)]
        public async Task<IActionResult> GetListClients()
        {
            var result = await _clientService.GetAll();
            return new JsonResult(result) { StatusCode = 200 };
        }


        /// <summary>
        /// Creates a new client with the provided details.
        /// </summary> 
        /// <param name="request">The details of the client to be created.</param>
        /// <response code="201">Client created successfully.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Clients), 201)]
        [ProducesResponseType(typeof(ApiError), 400)]
        //public async Task<IActionResult> CreateClient(ClientsRequest request)
        //{
        //    try
        //    {
        //        var result = await _clientService.CreateClient(request);
        //        return new JsonResult(result) { StatusCode = 201 };
        //    }
        //    catch (BadRequest ex)
        //    {
        //        return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
        //    }
        //    //catch (BadRequest)
        //    //{                
        //    //    return new JsonResult(new ApiError { Message = "Bad Request" });
        //    //}
        //}
        public async Task<IActionResult> CreateClient(ClientsRequest request)
        {   
            try
            {
                var result = await _clientService.CreateClient(request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }

        }

    }
}
