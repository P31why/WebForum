using Microsoft.AspNetCore.Mvc;

namespace WebForum.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
    }
}
