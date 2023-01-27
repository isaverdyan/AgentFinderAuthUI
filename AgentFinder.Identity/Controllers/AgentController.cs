using AgentFinder.Identity.Constants;
using AgentFinder.Identity.Context;
using AgentFinder.Identity.Models;
using AgentFinder.Identity.Models.Dto;
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
                .Include(u => u.userType)
                .Where(i => i.userType.UserTypeId == (ushort) UserTypes.Agent)
                .ToListAsync();
            return Ok(users);
        }

       [HttpPost("subscribe")]
       public async Task<IActionResult> Subscribe([FromBody] SubscribeToAgentViewModel agentVM)
       {
           if (ModelState.IsValid)
           {
               var userAgent = await _authContext.Users.FirstOrDefaultAsync(i =>
                   i.UserName == agentVM.AgentUserName);
               var agent = await _authContext.Agents.FirstOrDefaultAsync(i => i.User.Id == userAgent.Id);
               var userCustomer = await _authContext.Users.FirstOrDefaultAsync(i =>
                   i.UserName == agentVM.CustomerUserName);
                var customer =
                   await _authContext.Customers.FirstOrDefaultAsync(i => i.user.UserName == agentVM.CustomerUserName);
                customer.user = userCustomer;

               if (agent == null || customer == null) return BadRequest();

               try
               {

                   var agentCustomer = new AgentCustomer
                   {
                       Agent = agent,
                       Customer = customer,
                       SubscriptionDate = DateTime.Now
                   };

                   var result = await _authContext.AgentCustomers.AddAsync(agentCustomer);
                   await _authContext.SaveChangesAsync();

                   return Ok(result);
               }
               catch (Exception ex)
               {
                   string msg = ex.Message;

               }
           }

           return BadRequest();
       }
    }
}
