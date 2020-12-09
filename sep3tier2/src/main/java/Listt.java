import java.io.Serializable;
import java.util.List;

public class Listt implements Serializable {


    public List<User> list;

    public List<User> getlist()
    {
        return list;
    }

    public void setlist(List<User> list)
    {
        this.list = list;

    }

    public List<User> getList() {
        return list;
    }
}
