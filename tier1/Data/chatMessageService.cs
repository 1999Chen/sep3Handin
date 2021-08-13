using System.Collections.Generic;
using tier1.Models;
using tier1.Services;

namespace tier1.Data
{
    public class chatMessageService:IChatMessageService
    {
       public List<ChatMessage> getAllMessages(string username1,string username2)
       {
           return Client.getInstance().getAllMessages(username1, username2);

       }

       public void sendMessage(ChatMessage chatMessage)
       {
           Client.getInstance().sendMessage(chatMessage);
           
       }
       
    }
}