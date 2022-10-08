using Google.Cloud.Compute.V1;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using publiccloudgroup_api.DTO_s;
using publiccloudgroup_api.Interfaces;
using System.Net;

namespace publiccloudgroup_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CloudManagementController : ControllerBase
    {

        private readonly IVmOperations _vmOperations;

        public CloudManagementController(IVmOperations vmOperations)
        {
            _vmOperations = vmOperations;   
        }

        [HttpGet("GetVmList")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(typeof(IList<InstanceDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string),(int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetVmList()
        {
            (bool isSuccess, IList<InstanceDto> vmInstances, string responseMessage) = await _vmOperations.GetAllVmIntances(); 

            if (isSuccess)
                 return Ok(vmInstances);

            return BadRequest(responseMessage);
        }

        [HttpPost("StartSelectedVm")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> StartSelectedVm([FromBody] StartRequestModelDto startRequestModelDto)
        {
            (bool isSuccess, string responseMessage) = await _vmOperations.StartSelectedVm(startRequestModelDto);

            if (isSuccess)
                return Ok(responseMessage);

            return BadRequest(responseMessage);
        }

        [HttpPost("StopSelectedVm")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> StopSelectedVm([FromBody] StopRequestModelDto stopRequestModelDto)
        {
            (bool isSuccess, string responseMessage) = await _vmOperations.StopSelectedVm(stopRequestModelDto);

            if (isSuccess)
                return Ok(responseMessage);

            return BadRequest(responseMessage);
        }

        [HttpPost("SuspendSelectedVM")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> SuspendSelectedVm([FromBody] SuspendRequestModelDto suspendRequestModelDto)
        {
            (bool isSuccess, string responseMessage) = await _vmOperations.SuspendSelectedVm(suspendRequestModelDto);

            if (isSuccess)
                return Ok(responseMessage);

            return BadRequest(responseMessage);
        }

        [HttpPost("ResumeSelectedVM")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> ResumeSelectedVm([FromBody] ResumeRequestModelDto resumeRequestModelDto)
        {
            (bool isSuccess, string responseMessage) = await _vmOperations.ResumeSelectedVm(resumeRequestModelDto);

            if (isSuccess)
                return Ok(responseMessage);

            return BadRequest(responseMessage);
        }
    }
}