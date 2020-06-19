using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    // we have created a base controller which will serve a controller base for all the other controller we will create in futer.
    // we can now do the redundant task here in this controller 

    [ApiController]
    [Route("/api/[controller]")]
    public class BaseApiController : ControllerBase
    {
    }
}
