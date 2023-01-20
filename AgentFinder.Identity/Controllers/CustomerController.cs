using AgentFinder.Identity.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgentFinder.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _authContext;

        public CustomerController(AppDbContext authContext)
        {
            _authContext = authContext;
        }

        [HttpGet("list")]
        //[Authorize]
        public async Task<ActionResult> GetAllAsync()
        {
            var customers = await _authContext.Customers
                .Include(u => u.user).ToListAsync();

            return Ok(customers);
        }

        [HttpDelete("delete")]
        [Authorize]
        public async Task<ActionResult> DeleteCustomerAsync(int customerId)
        {
           var customer = await _authContext.Customers.FirstOrDefaultAsync(i => i.Id == customerId);
           var result = _authContext.Customers.Remove(customer);
            return Ok(result);
        }
    }
}
