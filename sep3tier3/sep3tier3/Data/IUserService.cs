using System.Collections.Generic;
using System.Threading.Tasks;
using sep3tier3.Models;

namespace sep3tier3.Data
{
    public interface IUserService
    {

        User LoginUser(User user);

        User RegisterUser(User user);

        List<User> getUsersByInfo(string firstname, string lastname, string sex,
            string major, string hometown, int maxage, int minage, string hobbies);

        IEnumerable<User> getAllUsers();

        void editInfo(User user);
        
        














    }
}