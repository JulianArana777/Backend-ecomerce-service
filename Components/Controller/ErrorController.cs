using API.ERRORS;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    
    [Route("errors/{code}")]
    public class ErrorController : BaseApiController
    {
        public IActionResult Error ( int code)
        {
            return new ObjectResult (new ApiResponse (code));
        }
    }
}