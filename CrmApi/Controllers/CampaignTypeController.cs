using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Response;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Swagger;
using Application.Interfaces;


namespace CrmApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CampaignTypeController : ControllerBase
    {
        private readonly ICampaignTypeServices _campaignTypeService;

        public CampaignTypeController(ICampaignTypeServices campaignTypeService)
        {
            _campaignTypeService = campaignTypeService;
        }

        /// <summary>
        /// Retrieves a list of all campaign types.
        /// </summary> 
        /// <response code="200">Success</response>
        [HttpGet]        
        [ProducesResponseType(typeof(GenericResponse[]), 200)]        
        public async Task<IActionResult> GetListCampaignTypes()
        {
            var result = await _campaignTypeService.GetAll();
            return new JsonResult(result) { StatusCode = 200 };           

        }


    }
}
