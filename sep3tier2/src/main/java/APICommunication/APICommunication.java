package APICommunication;

import Model.ChatMessage;
import Model.User;
import com.google.gson.Gson;
import org.apache.http.client.methods.*;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.CloseableHttpClient;
import org.apache.http.impl.client.HttpClients;
import org.json.JSONArray;
import org.json.JSONObject;

import java.io.*;
import java.lang.management.GarbageCollectorMXBean;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.ProtocolException;
import java.net.URL;

public final class APICommunication
{
    private static CloseableHttpClient client = HttpClients.createDefault();
    private static HttpPost httpPost;
    private static HttpGet httpGet;
    private static HttpPut httpPut;
    private static HttpDelete httpDelete;
    private static Gson gson=new Gson();


    public static synchronized JSONObject Login(String username, String password)
    {
        String responseBody = null;
        httpPost = new HttpPost("https://localhost:44380/users/Login");
        String json = "{\"Username\": \"" + username + "\",\"Password\": \"" + password + "\"}";
        StringEntity entity = null;
        try
        {
            entity = new StringEntity(json);

        } catch (UnsupportedEncodingException e)
        {
            e.printStackTrace();
        }
        httpPost.setEntity(entity);
        httpPost.setHeader("Accept", "application/json");
        httpPost.setHeader("Content-type", "application/json");
        CloseableHttpResponse response = null;
        try
        {
            response = client.execute(httpPost);
            responseBody = new String(response.getEntity().getContent().readAllBytes());
        } catch (IOException e)
        {
            e.getMessage();
        }
        if (responseBody == null)
        {
            return new JSONObject("{\"ResponseCode\": \"connect to T3 failed\"}");
        } else
        {
            return new JSONObject(responseBody);
        }
    }




    public static synchronized JSONObject Register(JSONObject user)
    {

        httpPost = new HttpPost("https://localhost:44380/users/register");
        String json = user.toString();
        StringEntity entity = null;
        try
        {
            entity = new StringEntity(json);

        } catch (UnsupportedEncodingException e)
        {
            e.printStackTrace();
        }
        httpPost.setEntity(entity);
        httpPost.setHeader("Accept", "application/json");
        httpPost.setHeader("Content-type", "application/json");
        CloseableHttpResponse response = null;
        try
        {
            response = client.execute(httpPost);
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        int responseCodeInt = response.getStatusLine().getStatusCode();
        JSONObject responseCode = new JSONObject("{\"ResponseCode\": \"" + responseCodeInt + "\"}");
        return responseCode;
    }




    public static synchronized JSONObject getUser(String username)
    {
        StringBuilder result = new StringBuilder();
        URL url = null;
        try
        {
            url = new URL("https://localhost:44380/users/getuser/" + username);
        } catch (MalformedURLException e)
        {
            e.printStackTrace();
        }
        HttpURLConnection conn = null;
        try
        {
            conn = (HttpURLConnection) url.openConnection();
            try
            {

                conn.setRequestProperty("Content-Type", "application/json");
                conn.setRequestMethod("GET");

            } catch (ProtocolException e)
            {
                e.printStackTrace();
            }
            BufferedReader rd;
            rd = new BufferedReader(new InputStreamReader(conn.getInputStream()));
            String line;
            while ((line = rd.readLine()) != null)
            {
                result.append(line);
            }
            rd.close();
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        try
        {
            if (conn.getResponseCode() != 200)
            {
                JSONObject JSONResult = new JSONObject("{\"ResponseCode\": \"" + conn.getResponseCode() + "\"}");
                return JSONResult;
            } else
            {
                JSONObject JSONResult = new JSONObject(result.toString());
                return JSONResult;
            }
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        return null;
    }




    public static synchronized JSONObject sendMessage(ChatMessage message)
    {

        httpPost = new HttpPost("https://localhost:44380/users/register");
        String json = message.toString();
        StringEntity entity = null;
        try
        {
            entity = new StringEntity(json);

        } catch (UnsupportedEncodingException e)
        {
            e.printStackTrace();
        }
        httpPost.setEntity(entity);
        httpPost.setHeader("Accept", "application/json");
        httpPost.setHeader("Content-type", "application/json");
        CloseableHttpResponse response = null;
        try
        {
            response = client.execute(httpPost);
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        int responseCodeInt = response.getStatusLine().getStatusCode();
        JSONObject responseCode = new JSONObject("{\"ResponseCode\": \"" + responseCodeInt + "\"}");
        return responseCode;
    }



    public static synchronized JSONObject editUser(String username, JSONObject data)
    {

        URL url = null;
        try
        {
            url = new URL("https://localhost:44380/users/" + username);
        } catch (MalformedURLException e)
        {
            e.printStackTrace();
        }
        HttpURLConnection httpCon = null;
        try
        {
            httpCon = (HttpURLConnection) url.openConnection();
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        httpCon.setDoOutput(true);
        try
        {
            httpCon.setRequestProperty("Content-Type", "application/json");
            httpCon.setRequestMethod("PUT");
        } catch (ProtocolException e)
        {
            e.printStackTrace();
        }
        try
        {
            OutputStreamWriter out = new OutputStreamWriter(httpCon.getOutputStream());
            User user=new User();
            user.username=username;
            user.password=data.getString("password");
            user.firstname=data.getString("firstname");
            user.lastname=data.getString("lastname");
            user.sex=data.getString("sex");
            user.hometown=data.getString("hometown");
            user.description=data.getString("description");
            user.age=data.getInt("age");
            user.major=data.getString("major");
            user.profilePicture= (byte[]) data.get("profilePicture");
            user.hobbies=data.getString("hobbies");

            String jsondata=gson.toJson(user);
            out.write(jsondata);
            out.close();
            httpCon.getInputStream();
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        JSONObject JSONResult = null;
        try
        {
            JSONResult = new JSONObject("{\"ResponseCode\": \"" + httpCon.getResponseCode() + "\"}");
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        return JSONResult;
    }




    public static synchronized JSONObject sendFriendRequest(){



    }




    public static synchronized JSONArray getUsersByInfo(String firstname, String lastname, String sex,
                                                           String major, String hometown, int maxage, int minage, String hobbies)
    {
        /**GETTING DATA ABOUT THE USER BY ID*/
        JSONObject userInfo = getUser(yourid, token);
        int sexPref = dataAboutUser.getInt("PersonSexualityId");
        String gender = dataAboutUser.getString("Gender");
        /***/
        StringBuilder result = new StringBuilder();
        URL url = null;
        try
        {
            url = new URL("https://localhost:44380/users/GetUsersByInfo/");
        } catch (MalformedURLException e)
        {
            e.printStackTrace();
        }
        HttpURLConnection conn = null;
        try
        {
            conn = (HttpURLConnection) url.openConnection();
            try
            {

                conn.setRequestProperty("Content-Type", "application/json");
                conn.setRequestMethod("GET");
            } catch (ProtocolException e)
            {
                e.printStackTrace();
            }
            BufferedReader rd;
            rd = new BufferedReader(new InputStreamReader(conn.getInputStream()));
            String line;
            while ((line = rd.readLine()) != null)
            {
                result.append(line);
            }
            rd.close();
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        try
        {
            if (conn.getResponseCode() != 200)
            {
                JSONArray JSONResult = new JSONArray("[{\"ResponseCode\": \"" + conn.getResponseCode() + "\"}]");
                return JSONResult;
            } else
            {
                JSONArray JSONResult = new JSONArray(result.toString());
                return JSONResult;
            }
        } catch (IOException e)
        {
            e.printStackTrace();
        }

        return null;

    }


    public static synchronized JSONObject like(int Fisher2Id, String token)
    {
        URL url = null;
        try
        {
            url = new URL("https://localhost:44380/users/Like");
        } catch (MalformedURLException e)
        {
            e.printStackTrace();
        }
        HttpURLConnection httpCon = null;
        try
        {
            httpCon = (HttpURLConnection) url.openConnection();
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        httpCon.setDoOutput(true);
        try
        {
            httpCon.setRequestProperty("Authorization", "Bearer " + token);
            httpCon.setRequestProperty("Content-Type", "application/json");
            httpCon.setRequestMethod("POST");
        } catch (ProtocolException e)
        {
            e.printStackTrace();
        }
        try
        {
            OutputStreamWriter out = new OutputStreamWriter(httpCon.getOutputStream());
            String Jsondata = "{\"Fisher2Id\": " + Fisher2Id + "}";
            out.write(Jsondata);
            out.close();
            httpCon.getInputStream();
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        JSONObject JSONResult = null;
        try
        {
            JSONResult = new JSONObject("{\"ResponseCode\": \"" + httpCon.getResponseCode() + "\"}");
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        return JSONResult;
    }


//    public static synchronized JSONObject reject(int Fisher2Id, String token)
//    {
//        URL url = null;
//        try
//        {
//            url = new URL("https://localhost:44380/users/Reject");
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
//            httpCon.setRequestProperty("Authorization", "Bearer " + token);
//            httpCon.setRequestProperty("Content-Type", "application/json");
//            httpCon.setRequestMethod("POST");
//        } catch (ProtocolException e)
//        {
//            e.printStackTrace();
//        }
//        try
//        {
//            OutputStreamWriter out = new OutputStreamWriter(httpCon.getOutputStream());
//            String Jsondata = "{\"Fisher2Id\": " + Fisher2Id + "}";
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

}

