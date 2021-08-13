using System.Collections.Generic;
using sep3tier3.Models;

namespace sep3tier3.Data
{
    public interface IChatMessageService
    {
        List<ChatMessage> getAllMessages();
        List<ChatMessage> GetMessages(string username1, string username2);
        ChatMessage sendMessage(ChatMessage chatMessage);
    }
}