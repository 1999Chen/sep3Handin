using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

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
            string s = "hahahahahahahhahaha";
            byte[] bytes = Encoding.Default.GetBytes(s);
            socket.Send(bytes);
            Console.WriteLine(bytes);


        }

      
    }
}