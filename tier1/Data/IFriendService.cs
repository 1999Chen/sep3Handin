using System.Collections.Generic;
using tier1.Models;


namespace tier1.Data
{
    public interface IFriendService
    {

        void delete(string username, string username2);
        List<Friend> getFriends(string username);
        void sendRequest(string username1, string username2);

        List<Friend> getRequests(string username);

        void agree(Friend friend);
    }
}