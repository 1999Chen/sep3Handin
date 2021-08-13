using System.Collections.Generic;
using tier1.Models;

namespace tier1.Data
{
    public interface IChatMessageService
    {
        List<ChatMessage> getAllMessages(string username1, string username2);
        void sendMessage(ChatMessage chatMessage);
    }
}