import com.google.gson.Gson;
import org.json.JSONObject;

import javax.sound.sampled.AudioFormat;
import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;


public class testServer {

    public static void main(String[] args) {

        try
        {

            ServerSocket serverSocket=new ServerSocket(8500);
            System.out.println("create succedds");
            Socket socket=serverSocket.accept(); //waiting for connecting. then go ahead

            System.out.println("connect succedds");

            InputStream in=socket.getInputStream();
            OutputStream out=socket.getOutputStream();


            byte[]bytes=new byte[1024];
            int len=in.read(bytes);
            String a=new String(bytes,0,len);

            System.out.println();

            Gson gson = new Gson();
            Listt list=gson.fromJson(a,Listt.class);

            System.out.println(list.getList().toString());


//            User user=gson.fromJson(a,User.class);

//            System.out.println(user.getName()+ " and age is "+user.getAge());

            System.out.println(a);


//            byte[] bytes1=new byte[1024];
//            int len1=in.read(bytes1);
//            System.out.println(new String(bytes1,0,len1));




            String toSend="okkkkkk";
            byte[] toSendBytes = toSend.getBytes();
            int toSendLen = toSendBytes.length;
            byte[] toSendLenBytes = new byte[4];
            toSendLenBytes[0] = (byte)(toSendLen & 0xff);
            toSendLenBytes[1] = (byte)((toSendLen >> 8) & 0xff);
            toSendLenBytes[2] = (byte)((toSendLen >> 16) & 0xff);
            toSendLenBytes[3] = (byte)((toSendLen >> 24) & 0xff);
            out.write(toSendLenBytes);
            out.write(toSendBytes);



        } catch (IOException e) {
            e.printStackTrace();
        }


    }

}
