using System;
using Microsoft.AspNetCore.Mvc;
using sep3tier3.Data;
using sep3tier3.Models;

namespace sep3tier3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class chatMessagesController:ControllerBase
    {
        private readonly IChatMessageService chatMessageService;

        public chatMessagesController(IChatMessageService chatMessageService)
        {
            this.chatMessageService = chatMessageService;
        }
        // [HttpPost("chatMessages")]
        // public IActionResult storeMessage([FromBody] ChatMessage chatMessage)
        // {
        //     userService.storeMessage(chatMessage);
        //     return Ok();
        // }

        [HttpGet]
        public IActionResult getAllMessages()
        {
            return Ok(chatMessageService.getAllMessages());
        }

        [HttpGet("GetMessages/{username1};{username2}")]
        public IActionResult getMessages(string username1, string username2)
        {
            Console.WriteLine("tier3 get msg controller");
            return Ok(chatMessageService.GetMessages(username1, username2));
        }

        [HttpPost("SendMessage")]
        public IActionResult sendMessage([FromBody]ChatMessage chatMessage)
        {
            Console.WriteLine("tier3 controller send msg"+chatMessage.message);
            Console.WriteLine(chatMessage.date);
            return Ok(chatMessageService.sendMessage(chatMessage));


        }
        
        
        
    }
}