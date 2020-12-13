import Model.User;
import com.google.gson.Gson;
import org.json.JSONObject;

import javax.sound.sampled.AudioFormat;
import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;


public class testServer {

    public static void main(String[] args) {

        try {

            ArrayList<Socket> socketArrayList = new ArrayList<>();
            HashMap<String, Socket> loginclients = new HashMap<>();
            ServerSocket serverSocket = new ServerSocket(8500);
            while (true) {

                System.out.println("create succedds");
                Socket socket = serverSocket.accept(); //waiting for connecting. then go ahead

                socketArrayList.add(socket);
                System.out.println("connect succedds");

                InputStream in = socket.getInputStream();
                OutputStream out = socket.getOutputStream();


                byte[] bytes = new byte[1024];
                int len = in.read(bytes);
                String a = new String(bytes, 0, len);

                System.out.println(a);

                Gson gson = new Gson();
//                byte[] bytes1 = gson.fromJson(a, byte[].class);

                User[] users = gson.fromJson(a, User[].class);




//            User user=gson.fromJson(a,User.class);

//            System.out.println(user.getName()+ " and age is "+user.getAge());

                System.out.println(a);


                String toSend = "okkkkkk";
                byte[] toSendBytes = toSend.getBytes();
                int toSendLen = toSendBytes.length;
                byte[] toSendLenBytes = new byte[4];
                toSendLenBytes[0] = (byte) (toSendLen & 0xff);
                toSendLenBytes[1] = (byte) ((toSendLen >> 8) & 0xff);
                toSendLenBytes[2] = (byte) ((toSendLen >> 16) & 0xff);
                toSendLenBytes[3] = (byte) ((toSendLen >> 24) & 0xff);
                out.write(toSendLenBytes);
                out.write(toSendBytes);

                if (a.equals("asd") && !loginclients.containsKey("asd")) {
                    loginclients.put("asd", socket);
                }

                if (a.equals("SendMessageREQUEST"))
                {



                }










            }

        } catch (IOException e) {
            e.printStackTrace();
        }

    }
}