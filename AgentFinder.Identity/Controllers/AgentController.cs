using AgentFinder.Identity.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgentFinder.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly AppDbContext _authContext;
        public AgentController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }


        [HttpGet("list")]
       // [Authorize]
        public async Task<ActionResult> GetAllAsync()
        {
            var users = await _authContext.Users
                .Include(u => u.userType).ToListAsync();

            return Ok(users);
        }
    }
}
