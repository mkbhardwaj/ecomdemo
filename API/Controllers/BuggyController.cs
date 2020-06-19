using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using API.Errors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private  StoreContext _storeContext { set; get; }

        public BuggyController(StoreContext context)
        {
            _storeContext = context;
        }


        [HttpGet("notfound")]
        public ActionResult GetNotFoundResult()
        {
            var t = _storeContext.Products.Find(42);

            if (t == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var t = _storeContext.Products.Find(42);

            var r = t.ToString();
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequestResult()
        {


            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundResult(int id)
        {
            
            return Ok();
        }


    }
}
