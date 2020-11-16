using System.Collections.Generic;
using System.Threading.Tasks;
using sep3tier3.Models;

namespace sep3tier3.Data
{
    public interface ImsgService
    {

        Task<msg> AddMsgAsync(msg msg);
        Task<string> GetAllMsgAsync();















    }
}