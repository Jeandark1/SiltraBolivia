using Microsoft.AspNetCore.Mvc;
using CargoApi.Application.Common;

namespace CargoApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        protected ActionResult<T> HandleResult<T>(ApiResponse<T> result)
        {
            if (result == null) return NotFound();

            if (result.Success)
            {
                return result.Data != null ? Ok(result) : NotFound(result);
            }

            return BadRequest(result);
        }

        protected ActionResult HandleResult(ApiResponse result)
        {
            if (result == null) return NotFound();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
