using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArdalisRatingWebApi.Controllers.api
{
    /// <summary>
    /// Base Api Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiControllerBase : ControllerBase
    {
    }
}