package SocketServer;

import APICommunication.APICommunication;
import Model.ChatMessage;
import Model.Friend;
import Model.LoginUser;
import Model.SearchUser;
import Model.User;
import com.google.gson.Gson;
import org.json.JSONArray;
import org.json.JSONObject;
import shared.Request;
import shared.RequestTypes;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.lang.module.FindException;
import java.net.Socket;

public class ServerThread extends Thread {
    private static Socket socket;
    private String clientUsername;
    private Gson gson = new Gson();

    public ServerThread(Socket socket) {
        this.socket = socket;
    }


    public void InitializeServer() {
        try {
            String json = "";
            InputStream in = socket.getInputStream();
            OutputStream out = socket.getOutputStream();

            APICommunication.enableSSL();
            int count;
            byte[] bytes = new byte[1024];
            System.out.println("server initialized");
            while (true) {

                while ((count = in.read(bytes)) != 0) {
                    json = new String(bytes, 0, count);

                    if (json.contains(";")) {
                        json.replace(";", "");
                        break;
                    }

                }
                JSONObject jsonObject = new JSONObject(json);
                Request request = new Request(jsonObject.getString("Type"), jsonObject.getJSONObject("Args"));//getting request type and arguments for it
                System.out.println(request.getType().toString());

                if (request.getType().equals(RequestTypes.REGISTER.toString())) {
                    System.out.println("Register");
                    User user = gson.fromJson(request.getArgs().toString(), User.class);
                    JSONObject responseCode = APICommunication.Register(user);
                    out.write(responseCode.toString().getBytes());
                    json = "";
                } else if (request.getType().equals(RequestTypes.LOGIN.toString())) {
                    System.out.println("Login");
                    LoginUser loginUser = new LoginUser(request.getArgs().getString("username"), request.getArgs().getString("password"));
                    JSONObject response1 = APICommunication.Login(loginUser);
                    out.write(response1.toString().getBytes());
                    json = "";
                } else if (request.getType().equals(RequestTypes.EDITINFO.toString())) {
                    System.out.println("Editinfo");
                    JSONObject data = request.getArgs();
                    String result = data.toString();
                    User user1 = gson.fromJson(result, User.class);
                    String response3 = APICommunication.editUser(user1);
                    System.out.println("edit tier2 socket");
                    out.write(response3.getBytes());

                } else if (request.getType().equals(RequestTypes.GETUSERINFO.toString())) {
                    System.out.println("GetUserInfo");
                    JSONObject arguments = request.getArgs();
                    String name = arguments.getString("username");
                    JSONObject responseFromAPI = APICommunication.getUserInfo(name);
                    System.out.println(responseFromAPI);
                    out.write(responseFromAPI.toString().getBytes());
                    json = "";
                }

                // friends following
                else if (request.getType().equals(RequestTypes.GETFRIENDS.toString())) {
                    System.out.println("GetFriends");
                    JSONObject arguments = request.getArgs();
                    String name = arguments.getString("username1");
                    JSONArray responseFromAPI = APICommunication.getFriends(name);
                    System.out.println(responseFromAPI);
                    out.write(responseFromAPI.toString().getBytes());
                    json = "";
                }
                else if (request.getType().equals(RequestTypes.GETMESSAGES.toString())) {
                    System.out.println("GetMessages");
                    JSONObject arguments = request.getArgs();
                    String username1 = arguments.getString("nameReceived");
                    String username2 = arguments.getString("nameSend");
                    System.out.println(username1);
                    JSONArray responseFromAPI = APICommunication.getMessages(username1,username2);
                    System.out.println(responseFromAPI);
                    out.write(responseFromAPI.toString().getBytes());
                    json = "";
                }

                else if (request.getType().equals(RequestTypes.SENDMESSAGE.toString())) {
                    System.out.println("tier2 socket SEND Messages");
                    String result=request.getArgs().toString();
                    System.out.println(result);
                    ChatMessage chatMessage=gson.fromJson(result,ChatMessage.class);
                    JSONObject responseFromAPI = APICommunication.sendMessage(chatMessage);
                    System.out.println(responseFromAPI);
                    out.write(responseFromAPI.toString().getBytes());
                    json = "";
                }

                else if (request.getType().equals(RequestTypes.DELETE.toString())) {
                    System.out.println("tier2 socket DELETE friends");
                    String result=request.getArgs().toString();
                    System.out.println(result);
                    Friend friend =gson.fromJson(result,Friend.class);
                    JSONObject responseFromAPI = APICommunication.delete(friend);
                    System.out.println(responseFromAPI);
                    out.write(responseFromAPI.toString().getBytes());
                    json = "";
                }
                else if (request.getType().equals(RequestTypes.SEARCHUSERS.toString())) {
                    System.out.println("tier2 socket SEARCH USERS ");
                    String result= request.getArgs().toString();
                    System.out.println(result);
                    SearchUser s = gson.fromJson(result, SearchUser.class);
                    JSONArray responseFromAPI = APICommunication.searchUsers(s);
                    System.out.println(responseFromAPI);
                    out.write(responseFromAPI.toString().getBytes());
                    json = "";
                }
                else if (request.getType().equals(RequestTypes.GETALLUSERS.toString())) {
                    System.out.println("tier2 socket get all USERS ");
                    String result= request.getArgs().toString();
                    System.out.println(result);
                    JSONArray responseFromAPI = APICommunication.getAllUsers();
                    System.out.println(responseFromAPI);
                    out.write(responseFromAPI.toString().getBytes());
                    json = "";
                }

                else if (request.getType().equals(RequestTypes.SENDFRIENDREQUEST.toString())) {
                    System.out.println("tier2 socket SEND REQUEST ");
                    String result= request.getArgs().toString();
                    System.out.println(result);
                    Friend s = gson.fromJson(result, Friend.class);
                    JSONObject responseFromAPI = APICommunication.sendFriendRequest(s);
                    System.out.println(responseFromAPI);
                    out.write(responseFromAPI.toString().getBytes());
                    json = "";
                }

                else if (request.getType().equals(RequestTypes.GETREQUEST.toString())) {
                    System.out.println("tier2 socket GET REQUEST ");
                    String result= request.getArgs().getString("username1");
                    System.out.println(result);
                    JSONArray responseFromAPI = APICommunication.getRequest(result);
                    System.out.println(responseFromAPI);
                    out.write(responseFromAPI.toString().getBytes());
                    json = "";
                }

                else if (request.getType().equals(RequestTypes.SENDFRIENDREQUEST.toString())) {
                    System.out.println("tier2 socket SEND REQUEST ");
                    String result= request.getArgs().toString();
                    System.out.println(result);
                    Friend s = gson.fromJson(result, Friend.class);
                    JSONObject responseFromAPI = APICommunication.sendFriendRequest(s);
                    System.out.println(responseFromAPI);
                    out.write(responseFromAPI.toString().getBytes());
                    json = "";
                }
                else if (request.getType().equals(RequestTypes.AGREE.toString())) {
                    System.out.println("tier2 socket agree ");
                    String result= request.getArgs().toString();
                    System.out.println(result);
                    Friend s = gson.fromJson(result, Friend.class);
                    JSONObject responseFromAPI = APICommunication.agree(s);
                    System.out.println(responseFromAPI);
                    out.write(responseFromAPI.toString().getBytes());
                    json = "";
                }

                else if (request.getType().equals(RequestTypes.LOGOUT.toString()))
                {
                    String message = "logout success";
                    out.write(new JSONObject("{\"message\": \"" + message + "\"}").toString().getBytes());
                    System.out.println("Client logout!");
                    break;
                }

                else
                    System.out.println("haha");

                Thread.sleep(100);
            }

        } catch (Exception e) {

            ClientManager.getInstance().removeClient(clientUsername);
            System.out.println("server thread exception " + e.getMessage());
        }

    }


    public void run() {
        InitializeServer();
    }

}
