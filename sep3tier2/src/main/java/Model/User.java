package Model;

import java.io.Serializable;
import java.util.Date;

public class User implements Serializable {
    private String username;
    private String password;
    private String firstname;
    private String lastname;
    private String sex;
    private String birthday;
    private String major;
    private String hometown;
    private String description;
    private int age;
    private String hobbies;

    public User() {
        this.username = "";
        this.password = "";
        this.firstname = "";
        this.lastname = "";
        this.sex = "";
        this.major = "";
        this.hometown = "";
        this.description = "";
        this.birthday = "";
        this.age = 0;
        hobbies="";
    }

}
