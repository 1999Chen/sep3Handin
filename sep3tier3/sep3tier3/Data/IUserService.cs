using System.Collections.Generic;
using System.Threading.Tasks;
using sep3tier3.Models;

namespace sep3tier3.Data
{
    public interface IUserService
    {

        User LoginUser(User user);

        User RegisterUser(User user);
        
        














    }
}