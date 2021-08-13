using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using sep3tier3.DataAccess;
using sep3tier3.Models;

namespace sep3tier3.Data
{
    public class chatMessageService : IChatMessageService
    {
        sepDBContext dbcontext = new sepDBContext();
        private List<ChatMessage> chatMessages;

        public chatMessageService()
        {
            chatMessages = new List<ChatMessage>();
        }

        public List<ChatMessage> getAllMessages()
        {
            var list1 = dbcontext.ChatMessages;
            var list = new List<ChatMessage>();

            foreach (var c in list1)
            {
                list.Add(c);
            }

            return list;
        }


        public List<ChatMessage> GetMessages(string username1, string username2)
        {
            var list1 = getAllMessages();
            var list = new List<ChatMessage>();
            foreach (var msg in list1)
            {
                if (msg.nameSend.Equals(username1) && msg.nameReceived.Equals(username2))
                {
                    list.Add(msg);
                }

                if (msg.nameSend.Equals(username2) && msg.nameReceived.Equals(username1))
                {
                    list.Add(msg);
                }
            }

            return list;
        }

        public ChatMessage sendMessage(ChatMessage chatMessage)
        {
            Console.WriteLine("sending message");
            try
            {
                int maxId = dbcontext.ChatMessages.Max(m => m.id);

                Console.WriteLine("MAX ID "+maxId);
                ChatMessage newchatMessage = new ChatMessage
                {
                    date = chatMessage.date,
                    nameReceived = chatMessage.nameReceived,
                    nameSend = chatMessage.nameSend,
                    message = chatMessage.message,
                    id = maxId + 1,
                };

                dbcontext.ChatMessages.Add(newchatMessage);
                dbcontext.SaveChanges();
                return newchatMessage;
            }
            catch (Exception e)
            {
                Console.WriteLine("you exception le!");
                ChatMessage newchatMessage = new ChatMessage
                {
                    date = chatMessage.date,
                    nameReceived = chatMessage.nameReceived,
                    nameSend = chatMessage.nameSend,
                    message = chatMessage.message,
                    id =  1,
                };

                dbcontext.ChatMessages.Add(newchatMessage);
                dbcontext.SaveChanges();
                return newchatMessage;
               
            }
        }
    }
}