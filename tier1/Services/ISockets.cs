using System;
using System.Collections.Generic;
using tier1.Models;

namespace tier1.Services
{
    public interface ISockets
    {

        void Connect();
     
        string  Login(string username, string password);

        string Register(string username, string password);
        

        string Edit(string username, string password, string firstname, string lastname, string hobbies,
         string sex, string hometown, string description, string major, int age,DateTime birthday);

        public User GetUserInfo(string username);

        List<ChatMessage> getAllMessages(string usernameSend, string usernameRecv);
        
        void Logout();

        List<Friend> GetFriendList(string username1);

        void sendMessage(ChatMessage chatMessage);
        
   

        void delete(string username1, string username2);

        string SendFriendRequest(Friend friend);

        List<User> Search(SearchUser searchUser);

        List<Friend> GetRequest(string username1);
        
        string agree(Friend friend);

        List<User> getAllUsers();

    }
}