using Microsoft.AspNetCore.Mvc;
using sep3tier3.Data;
using sep3tier3.Models;

namespace sep3tier3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class usersController:ControllerBase
    {

        private readonly IUserService userService;

        public usersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] User loginuser)
        {
            var user = userService.LoginUser(loginuser);

            if (user==null)
            {
                return BadRequest(new {message = "username or password is incorrect"});
            }

            return Ok(new User
            {
                username = loginuser.username,
                password = loginuser.password
            });
            
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] User registeruser)
        {
            var user = userService.RegisterUser(registeruser);

            if (user != )
            {
                
            }





        }
        

        














    }
}