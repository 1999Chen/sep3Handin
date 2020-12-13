package APICommunication;

import Model.ChatMessage;
import Model.UserSearch;
import com.google.gson.Gson;
import org.apache.http.client.methods.CloseableHttpResponse;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.CloseableHttpClient;
import org.apache.http.impl.client.HttpClients;
import org.json.JSONArray;
import org.json.JSONObject;

import java.io.*;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.ProtocolException;
import java.net.URL;

public final class cc
{
    private static CloseableHttpClient client = HttpClients.createDefault();
    private static HttpPost httpPost;
    private static Gson gson;

    public static synchronized JSONObject Login (String username,String password)
    {
        String responseBody = null;
        httpPost = new HttpPost("https://localhost:44380/users/login");
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
        String json = gson.toJson(user);
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

    public static synchronized JSONArray searchUsers(JSONObject userSearch, String token)
    {
        StringBuilder result = new StringBuilder();
        URL url = null;
        try
        {
            url = new URL("https://localhost:44380/users/getUsers/" + userSearch);
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
                conn.setRequestProperty("Authorization", "Bearer " + token);
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
                JSONArray JSONResult = new JSONArray("{\"ResponseCode\": \"" + conn.getResponseCode() + "\"}");
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

    public static synchronized JSONObject getUserByInfo(String userName, String token)
    {
        StringBuilder result = new StringBuilder();
        URL url = null;
        try
        {
            url = new URL("https://localhost:44380/users/getUserByInfo/" + userName);
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
                conn.setRequestProperty("Authorization", "Bearer " + token);
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

    public static synchronized JSONObject editUser(JSONObject user, String token)
    {
        URL url = null;
        try
        {
            url = new URL("https://localhost:44380/users/editUser");
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
            String Jsondata = user.toString();
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

    public static synchronized JSONArray getMessages(JSONObject message,String token)//chatmessage nameSend and nameReceive
    {
        StringBuilder result = new StringBuilder();
        URL url = null;
        try
        {
            url = new URL("https://localhost:44380/messages/getMessages" + message);
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
                conn.setRequestProperty("Authorization", "Bearer " + token);
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
                JSONArray JSONResult = new JSONArray("{\"ResponseCode\": \"" + conn.getResponseCode() + "\"}");
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

    public static synchronized JSONObject sendMessage(JSONObject message,String token)
    {
        URL url = null;
        try
        {
            url = new URL("https://localhost:44380/messages/sendMessage");
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
            String Jsondata = message.toString();
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


    public static synchronized JSONObject sendFriendRequest(JSONObject friend,String token)
    {
        URL url = null;
        try
        {
            url = new URL("https://localhost:44380/friends/sendRequest");
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
            String Jsondata = friend.toString();
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

    public static synchronized JSONObject acceptFriendRequest(Boolean accept,String token)
    {
        URL url = null;
        try
        {
            url = new URL("https://localhost:44380/friends/accept");
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
            String Jsondata = "{\"Accept\": " + accept + "}";
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

    public static synchronized JSONObject deleteFriendRequest(String username,String token)
    {
        URL url = null;
        try
        {
            url = new URL("https://localhost:44380/friends/delete");
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
            String Jsondata = "{\"Username\": " + username + "}";
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

    public static synchronized JSONArray getAllFriendRequest(String username,String token)
    {
        StringBuilder result = new StringBuilder();
        URL url = null;
        try
        {
            url = new URL("https://localhost:44380/friends/getAllFriends" + username);
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
                conn.setRequestProperty("Authorization", "Bearer " + token);
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
                JSONArray JSONResult = new JSONArray("{\"ResponseCode\": \"" + conn.getResponseCode() + "\"}");
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

}

