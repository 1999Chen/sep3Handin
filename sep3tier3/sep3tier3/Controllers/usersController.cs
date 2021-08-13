using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using sep3tier3.Data;
using sep3tier3.Models;

namespace sep3tier3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class usersController : ControllerBase
    {
        private readonly IUserService userService;

        public usersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody]LoginUser loginUser)
        {
            Console.WriteLine(loginUser);
            var result = userService.LoginUser(loginUser.username,loginUser.password);

            if (result == "F")
            {
                Console.WriteLine("tier 3 log in INFORMATION is wrong");
                return BadRequest(new {message = "Username or password is incorrect"});
            }

            return Ok(new {message = "Login success"});
        }
       

        [HttpPost("Register")]
        public IActionResult Register([FromBody] User registeruser)
        {
            var user = userService.RegisterUser(registeruser);

            if (user == null)
            {
                return BadRequest(new {message = "User exists"});
            }

            Console.WriteLine("asdasd");
            return Ok(new {message="Register succedds!"});
        }

        
        

        [HttpPost("EditUser")]
        public IActionResult EditUserInfo([FromBody] User user)
        {
            try
            {
                //Update user
                userService.editInfo(user);
                Console.WriteLine("tier 3 edit controller");
                return Ok(new {message="ok"});
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message});
            }
        }


        [HttpGet]
        public IActionResult GetAllUsers()
        {
           Console.WriteLine("GET USETS");
            return Ok(userService.getAllUsers());
           
        }
        
        
        [HttpGet("GetUserInfo/{username}")]
        public IActionResult GetUserInfo(string username)
        {
            Console.WriteLine("tier 3 getUserInfo");
            User user = userService.getUser(username);
            if (user!= null)
            {
                return Ok(user);
            }
            Console.WriteLine(username);
            return BadRequest("username not found");
        }
        //username};{firstname};{lastname};{sex};{major};{hometown};{hobbies
        //string username,string firstname,string lastname,string sex,string major,string hometown,string hobbies
        [HttpGet( "searchUsers/{searchUser}")]
        public IActionResult SearchUsers(String searchUser)
        {
            SearchUser search = JsonSerializer.Deserialize<SearchUser>(searchUser);
            var list = userService.searchUsers(search);
            return Ok(list);
        }

        [HttpPost("chatMessages")]
        public IActionResult storeMessage([FromBody] ChatMessage chatMessage)
        {
            userService.storeMessage(chatMessage);
            return Ok();
        }
        
        
    }
}