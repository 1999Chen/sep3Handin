import java.io.IOException;
import java.io.InputStream;
import java.net.ServerSocket;
import java.net.Socket;

public class testServer {

    public static void main(String[] args) {

        try
        {

            ServerSocket serverSocket=new ServerSocket(8500);
            System.out.println("create succedds");
            Socket socket=serverSocket.accept(); //waiting for connecting. then go ahead

            System.out.println("connect succedds");
            InputStream in=socket.getInputStream();
            byte[]bytes=new byte[1024];
            int len=in.read(bytes);
            System.out.println(new String(bytes,0,len));


        } catch (IOException e) {
            e.printStackTrace();
        }


    }

}
