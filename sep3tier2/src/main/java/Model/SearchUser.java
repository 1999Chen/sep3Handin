package Model;

public class SearchUser
{
    private String username;
    private String firstname;
    private String lastname;
    private String sex;
    private String hometown;
    private String major;
    private String hobbies;

    public SearchUser(String username, String firstname, String lastname, String sex, String hometown, String major, String hobbies) {
        this.username = username;
        this.firstname = firstname;
        this.lastname = lastname;
        this.sex = sex;
        this.hometown = hometown;
        this.major = major;
        this.hobbies = hobbies;
    }
}
