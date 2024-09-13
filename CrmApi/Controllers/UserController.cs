using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrmApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;

        public UserController(IUserServices userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Retrieves a list of all users.
        /// </summary> 
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(typeof(Users[]), 200)]
        public async Task<IActionResult> GetListUsers()
        {
            var result = await _userService.GetAll();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
