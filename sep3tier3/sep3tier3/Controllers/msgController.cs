// using System;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using sep3tier3.Data;
// using sep3tier3.Models;
//
// namespace sep3tier3.Controllers
// {
     // [ApiController]
     // [Route("[controller]")]
//     public class msgController : ControllerBase
//     {
//         private ImsgService _msgService;
//
//         public msgController(ImsgService msgService)
//         {
//             _msgService = msgService;
//         }
//
//         [HttpPost]
//         public IActionResult AddMsg([FromBody] msg msg)
//         {
//
//             try
//             {
//                 _msgService.AddMsgAsync(msg);
//                 return Ok();
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e);
//                 throw;
//             }
//         }
//         [HttpGet]
//         public async Task<ActionResult<string>> GetAllMsg()
//         {
//             return await _msgService.GetAllMsgAsync();
//         }
//         
//         
//     }
// }