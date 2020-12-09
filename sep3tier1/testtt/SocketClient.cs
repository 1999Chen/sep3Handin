using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace testtt
{
    public class SocketClient
    {
        private int port = 8500;
        
        private string host = "127.0.0.1";

        private static SocketClient instance=new SocketClient();
        
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

        IPEndPoint ipEndPoint;
        Socket socket;

        private SocketClient()
        {
            ipEndPoint = new IPEndPoint(ipAddress, port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }

        public static SocketClient getInstance()
        {
             
            return instance;

        }
        public void send()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 8500);
            Console.WriteLine("connect!");
            
            // string s = "hahahahahahahhahaha";
            // byte[] bytes = Encoding.Default.GetBytes(s);
            // socket.Send(bytes);
            // Console.WriteLine(bytes);

            User user=new User("asd",8);
            User user1=new User("sss",12);
            // string a = JsonSerializer.Serialize(user);
            // Console.WriteLine(a);
            // byte[] bytesa = Encoding.UTF8.GetBytes(a);
            // socket.Send(bytesa);
            // Console.WriteLine(bytesa);
            // Console.WriteLine(a);
            //
            var arraylist=new List<User>();
            arraylist.Add(user);
            arraylist.Add(user1);
            var list=new Listt();
            list.setlist(arraylist);
      
            Console.WriteLine(list.);

            string lis = JsonSerializer.Serialize(list);
            byte[] listbyte=new byte[1024];

            socket.Send(listbyte);
            
            Console.WriteLine(lis);
            Console.WriteLine(listbyte);
            
            
            byte[] rcvLenBytes = new byte[4];
            socket.Receive(rcvLenBytes);
            int rcvLen = System.BitConverter.ToInt32(rcvLenBytes, 0);
            byte[] rcvBytes = new byte[rcvLen];
            socket.Receive(rcvBytes);
            String rcv = System.Text.Encoding.ASCII.GetString(rcvBytes);

            Console.WriteLine("Client received: " + rcv);
            
            


          



        }

      
    }
}