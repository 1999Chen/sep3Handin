package Model;

import java.io.Serializable;

public class User implements Serializable {
    public String username;
    public String password;

    public User() {
        this.username = new String();
        this.password=new String();
    }

    public String getUserName() {
        return username;
    }

    public void setUserName(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
