using System.Collections.Generic;
using System.Threading.Tasks;
using sep3tier3.Models;

namespace sep3tier3.Data
{
    public interface IUserService
    {

        string LoginUser(string username, string password);

        User RegisterUser(User user);

        List<User> searchUsers(SearchUser searchUser);

        List<User> getAllUsers();

        void editInfo(User user);

        void storeMessage(ChatMessage chatMessage);

        User getUser(string username);














    }
}