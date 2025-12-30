using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.AppData;
using API.Intities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase

    {
        [HttpGet]
        public async Task <ActionResult<IReadOnlyList<AppUser>>> Get()
        {
            return  await context.user.ToListAsync();
           
        }

        [HttpGet("{id}")]

        public async Task <ActionResult <AppUser>> Get(string id)
        {
            var user = await context.user.FindAsync(id);
            if (user !=null)
            {
                return user;
            }
            else
            {
                return NotFound();
            }
        }


    }
}
