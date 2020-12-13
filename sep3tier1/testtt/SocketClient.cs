using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
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
        
        public byte[] GetPictureData(string imagePath)  
        {  
            FileStream fs = new FileStream(imagePath, FileMode.Open);  
            byte[] byteData = new byte[fs.Length];  
            fs.Read(byteData, 0, byteData.Length);  
            fs.Close();  
            return byteData;  
        } 
        
        public void send()
        {
            
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 8500);
        
            Console.WriteLine("connect!");
            
            User user=new User("asd",8);
            User user1=new User("sss",12);
            string a = JsonSerializer.Serialize(user);
           
            byte[] bytesa = Encoding.UTF8.GetBytes(a);
          
            var arraylist=new List<User>();
            arraylist.Add(user);
            arraylist.Add(user1);


            string lis = JsonSerializer.Serialize(arraylist);
            byte[] listbyte = Encoding.UTF8.GetBytes(lis);

             socket.Send(listbyte);
            // socket.Send(GetPictureData("C:/Users/yu/Desktop/nike3"));
            
          
          
            Console.WriteLine(lis);
            Console.WriteLine(listbyte);
            
            
            byte[] rcvLenBytes = new byte[4];
            socket.Receive(rcvLenBytes);
            int rcvLen = System.BitConverter.ToInt32(rcvLenBytes, 0);
            byte[] rcvBytes = new byte[rcvLen];
            socket.Receive(rcvBytes);
            String rcv = System.Text.Encoding.ASCII.GetString(rcvBytes);

            Console.WriteLine("Client received: " + rcv);
          
            
            Thread.Sleep(100000);

            

          
            }


        }

      
    }
