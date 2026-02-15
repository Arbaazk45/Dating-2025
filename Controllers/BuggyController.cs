using System;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BuggyController : BaseController
{
    [HttpGet("auth")]

    public IActionResult auth()
    {
        return Unauthorized();
    }

      [HttpGet("not-found")]

    public IActionResult userNotFound()
    {
        return NotFound();
    }

     [HttpGet("bad-request")]

    public IActionResult badRequest()
    {
        return BadRequest("This is a bad request");
    }

     [HttpGet("server-error")]
     public IActionResult serverError()
    {
        throw new Exception("server-error");
    }
}
