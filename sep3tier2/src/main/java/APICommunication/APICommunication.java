package APICommunication;

import Model.*;
import com.google.gson.Gson;
import okhttp3.*;
import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.*;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.CloseableHttpClient;
import org.apache.http.impl.client.HttpClients;
import org.json.JSONArray;
import org.json.JSONObject;


import java.io.*;
import java.util.List;

public final class APICommunication {
    private static Gson gson = new Gson();
    private static OkHttpClient sslClient = new OkHttpClient();

    public static synchronized void enableSSL() throws IOException
    {
        InputStream is = new FileInputStream("./new_ssl.cer");
        Okhttpssl okhttpssl = new Okhttpssl();
        sslClient = okhttpssl.getTrusClient(is);
    }

    public static synchronized JSONObject Login(LoginUser loginUser) throws IOException {
        String json = gson.toJson(loginUser);
        MediaType mediaType = MediaType.parse("application/json");
        RequestBody body = RequestBody.create(mediaType, json);
        Request request = new Request.Builder()
                .url("https://localhost:5000/users/Login")
                .method("POST", body)
                .addHeader("Accept", "application/json")
                .addHeader("Content-Type", "application/json")
                .build();
        Response response = sslClient.newCall(request).execute();
        JSONObject result = new JSONObject(response.body().string());
        if (response == null) {
            return new JSONObject("{\"ResponseCode\": \"Can't connect to T3 \"}");
        } else {
            System.out.println("THE RESULT IS"+result);
            return result;
        }
    }


    public static synchronized JSONObject Register(User user) throws IOException {

        System.out.println("registering tier2 API");
        String json = gson.toJson(user);
        MediaType mediaType = MediaType.parse("application/json");
        RequestBody body = RequestBody.create(mediaType, json);
        Request request = new Request.Builder()
                .url("https://localhost:5000/users/Register")
                .method("POST", body)
                .addHeader("Accept", "application/json")
                .addHeader("Content-Type", "application/json")
                .build();
        Response response = sslClient.newCall(request).execute();

        if (response == null) {
            return new JSONObject("{\"ResponseCode\": \"Can't connect to T3 \"}");
        } else {

            return new JSONObject(response.body().string());
//            return new JSONObject(responseBody);
        }
    }

    public static synchronized JSONArray getAllUsers()throws Exception {

        MediaType mediaType = MediaType.parse("application/json");
        Request request = new Request.Builder()
                .url("https://localhost:5000/users")
                .method("GET", null)
                .addHeader("Content-Type", "application/json")
                .build();
        Response response = sslClient.newCall(request).execute();
        String result = response.body().string();
        int responseCode = response.code();
        if (responseCode != 200) {
            JSONArray jsonArray = new JSONArray("{\"ResponseCode\": \"" + responseCode + "\"}");
            return jsonArray;
        } else {
            JSONArray jsonArray = new JSONArray(result);
            return jsonArray;

        }


    }
    public static synchronized String editUser(User user) throws IOException {

        System.out.println("edit tier2 API");
        String json = gson.toJson(user);
        MediaType mediaType = MediaType.parse("application/json");
        RequestBody body = RequestBody.create(mediaType, json);
        Request request = new Request.Builder()
                .url("https://localhost:5000/users/EditUser")
                .method("POST", body)
                .addHeader("Accept", "application/json")
                .addHeader("Content-Type", "application/json")
                .build();
        Response response = sslClient.newCall(request).execute();
        String result = response.body().string();
        System.out.println("edit tier2 API");
        return result;
    }


    public static synchronized JSONObject getUserInfo(String username) throws IOException {



        Request request = new Request.Builder()
                .url("https://localhost:5000/users/GetUserInfo/" + username)
                .method("GET", null)
                .addHeader("Content-Type", "application/json")
                .build();
        Response response = sslClient.newCall(request).execute();
        int ResponseCode = response.code();
        String result = response.body().string();
        System.out.println(ResponseCode);
        if (ResponseCode != 200) {
            JSONObject JSONResult = new JSONObject("{\"ResponseCode\": \"" + ResponseCode + "\"}");
            return JSONResult;
        } else {
            JSONObject JSONResult = new JSONObject(result);
            return JSONResult;
        }

    }

    public static synchronized JSONArray getFriends(String username1) throws IOException {


        Request request = new Request.Builder()
                .url("https://localhost:5000/friends/GetFriends/" + username1)
                .method("GET", null)
                .addHeader("Content-Type", "application/json")
                .build();
        Response response = sslClient.newCall(request).execute();
        String result = response.body().string();
        int responseCode = response.code();
        if (responseCode != 200) {
            JSONArray JSONResult = new JSONArray("{\"ResponseCode\": \"" + responseCode + "\"}");
            return JSONResult;
        } else {
            JSONArray jsonArray = new JSONArray(result);
            return jsonArray;

        }

    }

    public static synchronized JSONArray getMessages(String username1, String username2) throws IOException {
        Request request = new Request.Builder()
                .url("https://localhost:5000/chatMessages/GetMessages/" + username1 + ";" + username2)
                .method("GET", null)
                .addHeader("Content-Type", "application/json")
                .build();
        Response response = sslClient.newCall(request).execute();
        String result = response.body().string();
        int responseCode = response.code();
        if (responseCode != 200) {
            JSONArray JSONResult = new JSONArray("{\"ResponseCode\": \"" + responseCode + "\"}");
            return JSONResult;
        } else {
            JSONArray jsonArray = new JSONArray(result);
            return jsonArray;

        }
    }

    public static synchronized JSONObject sendMessage(ChatMessage chatmessage) throws IOException {



        MediaType mediaType = MediaType.parse("application/json");
        String json = gson.toJson(chatmessage);
        System.out.println(json);
        RequestBody body = RequestBody.create(mediaType, json);
        Request request = new Request.Builder()
                .url("https://localhost:5000/chatMessages/SendMessage")
                .method("POST", body)
                .addHeader("Content-Type", "application/json")
                .build();
        Response response = sslClient.newCall(request).execute();
        int ResponseCode = response.code();
        String result = response.body().string();
        System.out.println(ResponseCode);
        if (ResponseCode != 200) {
            JSONObject JSONResult = new JSONObject("{\"ResponseCode\": \"" + ResponseCode + "\"}");
            return JSONResult;
        } else {
            JSONObject JSONResult = new JSONObject(result);
            return JSONResult;
        }


    }

    public static synchronized JSONObject delete(Friend friend)throws Exception
    {

        MediaType mediaType = MediaType.parse("application/json");
        String json= gson.toJson(friend);
        RequestBody body = RequestBody.create(mediaType, json);
        Request request = new Request.Builder()
                .url("https://localhost:5000/friends/Delete")
                .method("DELETE", body)
                .addHeader("Content-Type", "application/json")
                .build();
        Response response = sslClient.newCall(request).execute();
        int ResponseCode = response.code();
        String result = response.body().string();
        System.out.println(ResponseCode);
        if (ResponseCode != 200) {
            JSONObject JSONResult = new JSONObject("{\"ResponseCode\": \"" + ResponseCode + "\"}");
            return JSONResult;
        } else {
            JSONObject JSONResult = new JSONObject(result);
            return JSONResult;
        }
    }


    public static synchronized JSONArray searchUsers(SearchUser searchUser) throws IOException {
        String json=gson.toJson(searchUser);


        Request request = new Request.Builder()
                .url("https://localhost:5000/users/searchUsers/"+json)
                .method("GET", null)
                .addHeader("Content-Type", "application/json")
                .build();
        Response response = sslClient.newCall(request).execute();
        int ResponseCode = response.code();
        String result = response.body().string();
        System.out.println(ResponseCode);
        if (ResponseCode != 200) {
            JSONArray JSONarray = new JSONArray("{\"ResponseCode\": \"" + ResponseCode + "\"}");
            return JSONarray;
        } else {
            JSONArray jsonArray = new JSONArray(result);
            return jsonArray;
        }

    }

    public static synchronized JSONObject sendFriendRequest(Friend friend) throws IOException {
        MediaType mediaType = MediaType.parse("application/json");
        String json=gson.toJson(friend);
        RequestBody body = RequestBody.create(mediaType, json);
        Request request = new Request.Builder()
                .url("https://localhost:5000/friends/sendfriendrequest")
                .method("POST", body)
                .addHeader("Content-Type", "application/json")
                .build();
        Response response = sslClient.newCall(request).execute();
        int ResponseCode = response.code();
        String result = response.body().string();
        System.out.println(ResponseCode);
        if (ResponseCode != 200) {
            JSONObject JSONResult = new JSONObject("{\"ResponseCode\": \"" + ResponseCode + "\"}");
            return JSONResult;
        } else {
            JSONObject JSONResult = new JSONObject(result);
            return JSONResult;
        }
    }

    public static synchronized JSONArray getRequest(String username1) throws IOException {

        Request request = new Request.Builder()
                .url("https://localhost:5000/friends/GetFriendRequest/"+username1)
                .method("GET", null)
                .addHeader("Content-Type", "application/json")
                .build();
        Response response = sslClient.newCall(request).execute();
        int ResponseCode = response.code();
        String result = response.body().string();
        System.out.println(ResponseCode);
        if (ResponseCode != 200) {
            JSONArray JSONarray = new JSONArray("{\"ResponseCode\": \"" + ResponseCode + "\"}");
            return JSONarray;
        } else {
            JSONArray jsonArray = new JSONArray(result);
            return jsonArray;
        }

    }

    public static synchronized JSONObject agree(Friend friend)throws Exception
    {
        MediaType mediaType = MediaType.parse("application/json");
        String json= gson.toJson(friend);
        RequestBody body = RequestBody.create(mediaType, json);
        Request request = new Request.Builder()
                .url("https://localhost:5000/friends/agree")
                .method("POST", body)
                .addHeader("Content-Type", "application/json")
                .build();
        Response response = sslClient.newCall(request).execute();
        int ResponseCode = response.code();
        String result = response.body().string();
        System.out.println(ResponseCode);
        if (ResponseCode != 200) {
            JSONObject JSONResult = new JSONObject("{\"ResponseCode\": \"" + ResponseCode + "\"}");
            return JSONResult;
        } else {
            JSONObject JSONResult = new JSONObject(result);
            return JSONResult;
        }

    }



}








//
//
//    public static synchronized JSONObject getUser(String username)
//    {
//        StringBuilder result = new StringBuilder();
//        URL url = null;
//        try
//        {
//            url = new URL("https://localhost:5000/users/getuser/" + username);
//        } catch (MalformedURLException e)
//        {
//            e.printStackTrace();
//        }
//        HttpURLConnection conn = null;
//        try
//        {
//            conn = (HttpURLConnection) url.openConnection();
//            try
//            {
//
//                conn.setRequestProperty("Content-Type", "application/json");
//                conn.setRequestMethod("GET");
//
//            } catch (ProtocolException e)
//            {
//                e.printStackTrace();
//            }
//            BufferedReader rd;
//            rd = new BufferedReader(new InputStreamReader(conn.getInputStream()));
//            String line;
//            while ((line = rd.readLine()) != null)
//            {
//                result.append(line);
//            }
//            rd.close();
//        } catch (IOException e)
//        {
//            e.printStackTrace();
//        }
//        try
//        {
//            if (conn.getResponseCode() != 200)
//            {
//                JSONObject JSONResult = new JSONObject("{\"ResponseCode\": \"" + conn.getResponseCode() + "\"}");
//                return JSONResult;
//            } else
//            {
//                JSONObject JSONResult = new JSONObject(result.toString());
//                return JSONResult;
//            }
//        } catch (IOException e)
//        {
//            e.printStackTrace();
//        }
//        return null;
//    }
//
//
//    public static synchronized JSONObject storeMessage(ChatMessage message)
//    {
//
//        httpPost = new HttpPost("https://localhost:5000/chatMessages/storeMessage");
//        String json = gson.toJson(message);
//        StringEntity entity = null;
//        try
//        {
//            entity = new StringEntity(json);
//
//        } catch (UnsupportedEncodingException e)
//        {
//            e.printStackTrace();
//        }
//        httpPost.setEntity(entity);
//        httpPost.setHeader("Accept", "application/json");
//        httpPost.setHeader("Content-type", "application/json");
//        CloseableHttpResponse response = null;
//        try
//        {
//            response = client.execute(httpPost);
//        } catch (IOException e)
//        {
//            e.printStackTrace();
//        }
//        int responseCodeInt = response.getStatusLine().getStatusCode();
//        JSONObject responseCode = new JSONObject("{\"ResponseCode\": \"" + responseCodeInt + "\"}");
//        return responseCode;
//    }
//
//


//
//
//
//    public static synchronized JSONObject sendFriendRequest(JSONObject friend)
//    {
//        URL url = null;
//        try
//        {
//            url = new URL("https://localhost:5000/friends/sendFriendRequest");
//        } catch (MalformedURLException e)
//        {
//            e.printStackTrace();
//        }
//        HttpURLConnection httpCon = null;
//        try
//        {
//            httpCon = (HttpURLConnection) url.openConnection();
//        } catch (IOException e)
//        {
//            e.printStackTrace();
//        }
//        httpCon.setDoOutput(true);
//        try
//        {
//            httpCon.setRequestProperty("Content-Type", "application/json");
//            httpCon.setRequestMethod("POST");
//        } catch (ProtocolException e)
//        {
//            e.printStackTrace();
//        }
//        try
//        {
//            OutputStreamWriter out = new OutputStreamWriter(httpCon.getOutputStream());
//            String Jsondata = friend.toString();
//            out.write(Jsondata);
//            out.close();
//            httpCon.getInputStream();
//        } catch (IOException e)
//        {
//            e.printStackTrace();
//        }
//        JSONObject JSONResult = null;
//        try
//        {
//            JSONResult = new JSONObject("{\"ResponseCode\": \"" + httpCon.getResponseCode() + "\"}");
//        } catch (IOException e)
//        {
//            e.printStackTrace();
//        }
//        return JSONResult;
//    }
//
//
//
//
//    public static synchronized JSONArray searchUsers(String firstname, String lastname, String sex,
//                                                           String major, String hometown, int maxage, int minage, String hobbies)
//    {
//
//        StringBuilder result = new StringBuilder();
//        URL url = null;
//        try
//        {
//            url = new URL("https://localhost:5000/users/SearchUsers");
//        } catch (MalformedURLException e)
//        {
//            e.printStackTrace();
//        }
//        HttpURLConnection conn = null;
//        try
//        {
//            conn = (HttpURLConnection) url.openConnection();
//            try
//            {
//
//                conn.setRequestProperty("Content-Type", "application/json");
//                conn.setRequestMethod("GET");
//            } catch (ProtocolException e)
//            {
//                e.printStackTrace();
//            }
//            BufferedReader rd;
//            rd = new BufferedReader(new InputStreamReader(conn.getInputStream()));
//            String line;
//            while ((line = rd.readLine()) != null)
//            {
//                result.append(line);
//            }
//            rd.close();
//        } catch (IOException e)
//        {
//            e.printStackTrace();
//        }
//        try
//        {
//            if (conn.getResponseCode() != 200)
//            {
//                JSONArray JSONResult = new JSONArray("[{\"ResponseCode\": \"" + conn.getResponseCode() + "\"}]");
//                return JSONResult;
//            } else
//            {
//                JSONArray JSONResult = new JSONArray(result.toString());
//                return JSONResult;
//            }
//        } catch (IOException e)
//        {
//            e.printStackTrace();
//        }
//
//        return null;
//
//    }


