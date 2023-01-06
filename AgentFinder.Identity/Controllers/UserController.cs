using System.Text;
using System.Text.RegularExpressions;
using AgentFinder.Identity.Context;
using AgentFinder.Identity.Helpers;
using AgentFinder.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgentFinder.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _authContext;
        public UserController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();

            var user = await _authContext.Users
                .FirstOrDefaultAsync(x => x.UserName == userObj.UserName);

            if (user == null)
                return NotFound(new { Message = "User not found!" });

            if (!PasswordHasher.VerifyPassword(userObj.Password, user.Password))
            {
                return BadRequest(new {Message = "Password is incorrect!"});
            }

            return Ok(new
            {
                Message = "Login success!"
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();

            //check username
            if (await CheckUserNameExistsAsync(userObj.UserName))
                return BadRequest(new {Message = "Username already exists"});

            //check email
            if (await CheckEmailExistsAsync(userObj.Email))
                return BadRequest(new { Message = "Email already exists" });

            //check password strength
            var pass = CheckPasswordStrength(userObj.Password);
            if (!string.IsNullOrEmpty(pass))
                return BadRequest(new {Message = pass.ToString()});

            userObj.Password = PasswordHasher.HashPassword(userObj.Password);
            userObj.Role = "User";
            userObj.Token = "";
            await _authContext.Users.AddAsync(userObj);
            await _authContext.SaveChangesAsync();

            return Ok(new
            {
                Message = "User Registered!"
            });
        }

        private Task<bool> CheckUserNameExistsAsync(string username) =>
            _authContext.Users.AnyAsync(x => x.UserName == username);

        private Task<bool> CheckEmailExistsAsync(string email) =>
            _authContext.Users.AnyAsync(x => x.Email == email);

        private string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();
            if (password.Length < 8)
                sb.Append("Minimum required length is 8" + Environment.NewLine);
            if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]") &&
                  Regex.IsMatch(password, "[0-9]")))
                sb.Append("Password should be Alphanumeric"+Environment.NewLine);
            if (!(Regex.IsMatch(password, "[<,>,@,!,*,$,&,),(,:,;,\\[,\\],_,-,{,},~,|,\\,`,=,+,^,?]")))
                sb.Append("Password should contain special character"+Environment.NewLine);

            return sb.ToString();
        }

    }
}
