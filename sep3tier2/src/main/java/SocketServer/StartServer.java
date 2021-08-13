package SocketServer;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class StartServer {

    public static ServerSocket serverSocket = null;

    static
    {
        try {
            serverSocket = new ServerSocket(8500);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static void main(String[] args)
    {
        Socket socket = new Socket();
        try
        {
            while (true)
            {
                socket = serverSocket.accept();
                new ServerThread(socket).start();

            }
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }

}
