using System;
using System.Collections.Generic;
using System.Net;
using System.Net.WebSockets;
using tier1.Models;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Linq;
using System.Threading;
using Assignment.Pages;
using Newtonsoft.Json.Linq;


namespace tier1.Services
{
    public class Sockets : ISockets
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        // public Sockets()
        // {
        //     IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        //     IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8500);
        //     socket.Connect(ipEndPoint);
        //     Console.WriteLine("Connect success!");
        // }

        public void Connect()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8500);
            socket.Connect(ipEndPoint);
            Console.WriteLine("Connect success!");
        }


        public string SendAndReceive(Request request)
        {
            Thread.Sleep(100);
            var json = JsonSerializer.Serialize(request);
            Console.WriteLine("send:" + json);
            byte[] bytes = Encoding.UTF8.GetBytes(json + ";");
            socket.Send(bytes);
            string recv = "";
            byte[] recvBytes = new byte[1024];
            int bytesa;
            bytesa = socket.Receive(recvBytes, recvBytes.Length, 0);
            recv += Encoding.UTF8.GetString(recvBytes, 0, bytesa);
            Console.WriteLine("receive ok " + recv);
            return recv;
        }

        // public string receive()
        // {
        //     string recv = "";
        //     byte[] recvBytes = new byte[1024];
        //     int bytes;
        //     bytes = socket.Receive(recvBytes, recvBytes.Length, 0);
        //     recv += Encoding.ASCII.GetString(recvBytes, 0, bytes);
        //     return recv;
        // }
        
        public string Login(string username, string password)
        {
            Request request = new Request()
            {
                Type = RequestTypes.LOGIN.ToString(),
                Args = new User {username = username, password = password}
            };
            Console.WriteLine(username+password);
            string recv = SendAndReceive(request);
            Message message = JsonSerializer.Deserialize<Message>(recv);

            return message.ToString();
        }

        public string Register(string username, string password)
        {
            Request request = new Request()
            {
                Type = RequestTypes.REGISTER.ToString(),
                Args = new User {username = username, password = password}
            };
            string recv = SendAndReceive(request);
            Message message = JsonSerializer.Deserialize<Message>(recv);
            return message.ToString();
        }

        public List<User> Search(SearchUser searchUser)
        {
            List<User> list = new List<User>();
            Request request = new Request()
            {
                Type = RequestTypes.SEARCHUSERS.ToString(),
                Args = searchUser,
            };
            string recv = SendAndReceive(request);
            Console.WriteLine(recv);
            list = JsonSerializer.Deserialize<List<User>>(recv);
            return list;
        }

        public User GetUserInfo(string username)
        {
            Request request = new Request()
            {
                Type = RequestTypes.GETUSERINFO.ToString(),
                Args = new User {username = username}
            };
            string recv = SendAndReceive(request);
            User user = JsonSerializer.Deserialize<User>(recv);
            return user;
        }

        public string Edit(string username, string password, string firstname, string lastname, string hobbies,
            string sex, string hometown, string description, string major, int age, DateTime birthday)
        {
            Console.WriteLine("edit tier1 socket1");
            Request request = new Request
            {
                Type = RequestTypes.EDITINFO.ToString(),
                Args = new User
                {
                    username = username,
                    password = password,
                    sex = sex,
                    hobbies = hobbies,
                    firstname = firstname,
                    lastname = lastname,
                    hometown = hometown,
                    major = major,
                    age = age,
                    description = description,
                    birthday = new Birthday
                    {
                        year = birthday.Year,
                        month = birthday.Month,
                        day = birthday.Day
                    }.ToString()
                }
            };

            string recv = SendAndReceive(request);
            Message message = JsonSerializer.Deserialize<Message>(recv);
            return message.ToString();
        }

        public string SendFriendRequest(Friend friend)
        {
            Request request = new Request()
            {
                Type = RequestTypes.SENDFRIENDREQUEST.ToString(),
                Args = friend
            };
            string recv = SendAndReceive(request);
            return recv;
            
        }

        public string agree(Friend friend)
        {
            Request request = new Request()
            {
                Type = RequestTypes.AGREE.ToString(),
                Args = friend
            };
            string recv = SendAndReceive(request);
            return recv;

            
            
        }
        
        public List<Friend> GetRequest(string username1)
        {
            Request request = new Request()
            {
                Type = RequestTypes.GETREQUEST.ToString(),
                Args = new Friend{username1=username1,}
            };
            string recv = SendAndReceive(request);
            var list = JsonSerializer.Deserialize<List<Friend>>(recv);
            return list;

        }
        
        

        public List<Friend> GetFriendList(string username1)
        {
            Console.WriteLine("tier1 get friends");
            Request request = new Request()
            {
                Type = RequestTypes.GETFRIENDS.ToString(),
                Args = new Friend()
                {
                    username1 = username1
                }
            };
            string recv = SendAndReceive(request);
            Friend[] friends = JsonSerializer.Deserialize<Friend[]>(recv);
            var list = new List<Friend>();
            foreach (var f in friends)
            {
                list.Add(f);
            }

            Console.WriteLine(friends.ToString());
            return list;
        }

        public void Logout()
        {
            Request request = new Request()
            {
                Type = RequestTypes.LOGOUT.ToString(),
                Args = new Message
                {
                    message = "logout"
                }
            };
            string recv = SendAndReceive(request);
            socket.Close();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }


        public void sendMessage(ChatMessage chatMessage)
        {
            Console.WriteLine("tier 1 send msg sockets");
            Request request = new Request
            {
                Type = RequestTypes.SENDMESSAGE.ToString(),
                Args = new ChatMessage()
                {
                    message = chatMessage.message,
                    date = DateTime.Now.ToString("G"),
                    nameReceived = chatMessage.nameReceived,
                    nameSend = chatMessage.nameSend,
                }
            };
            SendAndReceive(request);
        }

        public List<ChatMessage> getAllMessages(string username1, string username2)
        {
            Console.WriteLine("tier1 socket get message");
            Request request = new Request
            {
                Type = RequestTypes.GETMESSAGES.ToString(),
                Args = new ChatMessage()
                {
                    nameReceived = username1,
                    nameSend = username2
                }
            };
            string recv = SendAndReceive(request);
            ChatMessage[] chatMessages = JsonSerializer.Deserialize<ChatMessage[]>(recv);
            var list = new List<ChatMessage>();
            foreach (var chat in chatMessages)
            {
                list.Add(chat);
            }

            Console.WriteLine(chatMessages.ToString());
            return list;
        }


        public void delete(string username1, string username2)
        {
            Console.WriteLine("tier 1 delete");
            Request request = new Request
            {
                Type = RequestTypes.DELETE.ToString(),
                Args = new Friend
                {
                    accept = true,
                    username1 = username1,
                    username2 = username2
                }

            };
                
            Console.WriteLine("delete tier1 socket");
            SendAndReceive(request);
        }


        public List<User> getAllUsers()
        {
            Console.WriteLine("tier 1 get all");
            Request request = new Request
            {
                Type = RequestTypes.GETALLUSERS.ToString(),
                Args = new User()
                {
                }
            };

            Console.WriteLine("get all tier1 socket");
            string recv = SendAndReceive(request);
            var list = JsonSerializer.Deserialize<List<User>>(recv);
            return list;
            
          
        }
        
       
    }
}