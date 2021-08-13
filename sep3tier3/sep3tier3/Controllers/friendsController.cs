using System;
using Microsoft.AspNetCore.Mvc;
using sep3tier3.Data;
using sep3tier3.Models;

namespace sep3tier3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class friendsController:ControllerBase
    {
        private readonly IFriendService friendService;

        public friendsController(IFriendService friendService)
        {
            this.friendService = friendService;
        }

        [HttpGet("GetFriends/{username1}")]
        public IActionResult GetFriends(string username1)
        {
            Console.WriteLine("tier 3 get friends");
            return Ok(friendService.getFriends(username1));
        }

        [HttpGet]
        public IActionResult GetAllFriends()
        {
            return Ok(friendService.getAllFriends());
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] Friend friend)
        {
            return Ok(friendService.delete(friend));
        }

        [HttpPost("SendFriendRequest")]
        public IActionResult SendFriendRequest([FromBody]Friend friend)
        {
            return Ok(friendService.sendFriendRequest(friend));
        }

        [HttpGet("GetFriendRequest/{username1}")]
        public IActionResult GetFriendRequest(string username1)
        {
            return Ok(friendService.getFriendRequest(username1));
        }

        [HttpPost("Agree")]
        public IActionResult Agree([FromBody]Friend friend)
        {
            return Ok(friendService.agree(friend));
        }
        
        
        
        
        
    }
}