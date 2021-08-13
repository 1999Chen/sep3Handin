using System;
using System.Collections.Generic;
using tier1.Models;
using tier1.Services;

namespace tier1.Services {
public class Client
{
    
    private static Client client = new Client();
    private static int checkCode = 0;
    
    ISockets sockets=new Sockets();
    
    private Client()
    {
    }
    public static Client getInstance()
    {
        return client;
    }

    public void Connect()
    {
        if (checkCode==0)
        {
            sockets.Connect();
            checkCode = 1;
        }
        Console.WriteLine("already connect");
    }

    public User getUserInfo(string username)
    {
        return sockets.GetUserInfo(username);
    }

    public List<User> searchUsers(SearchUser searchUser)
    {

        return sockets.Search(searchUser);
    }

    public List<User> getAllUsers()
    {
        return sockets.getAllUsers();
    }
    
    public User ValidateUser(string username, string password)
    {
        
       string a= sockets.Login(username,password);
       if (a=="Login success")
           return new User
           {
               username = username,
               password = password
           };
       return null;
    }
    
    public string RegisterUser(string username, string password)
    {
        string result=sockets.Register(username, password);

        return result;
    }
    

    public void logout()
    {
        if (checkCode==1)
        {
            checkCode = 0;
        }
        sockets.Logout();
    }

    public void editInfo(string username, string password,string firstname,string lastname, string hobbies,  string sex, string hometown, string description, string major, int age,DateTime birthday)
    {
        sockets.Edit(username, password, firstname, lastname, hobbies, sex, hometown, description, major, age,birthday);
    }
    
    
    public string currentName { get; set; }

    public List<Friend> getFriends(string username1)
    {
        return sockets.GetFriendList(username1);

    }

    public void delete(string username1, string username2)
    {
        sockets.delete(username1,username2);
    }

    public string sendRequest(string username1,string username2)
    {
        Friend friend = new Friend
        {
            username1 = username1,
            username2 = username2,
            accept=false
        };
       return sockets.SendFriendRequest(friend);

    }

    public List<Friend> getRequests(string username)
    {
       return sockets.GetRequest(username);

    }
    
    public void agree(Friend friend)
    {
        sockets.agree(friend);
    }

    public void sendMessage(ChatMessage chatMessage)
    {
        sockets.sendMessage(chatMessage);
    }
    
    public List<ChatMessage> getAllMessages(string username1,string username2)
    {
        return sockets.getAllMessages(username1, username2);

    }

    public int getCheckCode()
    {
        return checkCode;
    }
    
    
    
    
    
    
    
    
    
    
    
    

}
}