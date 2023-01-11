using AgentFinder.Identity.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgentFinder.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuOptionsController : ControllerBase
    {
        private readonly AppDbContext _authContext;
        public MenuOptionsController(AppDbContext authContext)
        {
            _authContext = authContext;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            var menuList = await _authContext.MenuOptions.ToListAsync();

            return Ok(menuList);
        }
    }
}
