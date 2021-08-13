using System;
using System.Collections.Generic;
using tier1.Data;
using tier1.Models;
using tier1.Services;


namespace tier1.Data
{
    public class friendService : IFriendService
    {

        public void sendRequest(string username1, string username2)
        {
            Client.getInstance().sendRequest(username1,username2);
        }
        
        public void delete(string username1,string username2)
        {
            Client.getInstance().delete(username1,username2);
        }

        public void agree(Friend friend)
        {
            
            Client.getInstance().agree(friend);
            
        }

        public List<Friend> getRequests(string username)
        {
           return Client.getInstance().getRequests(username);
        }
        
        
        public List<Friend> getFriends(string username)
        {
            return Client.getInstance().getFriends(username);
        }
    }
}