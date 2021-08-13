using System.Collections.Generic;
using sep3tier3.Models;

namespace sep3tier3.Data
{
    public interface IFriendService
    {
        List<Friend> getAllFriends();
        List<Friend> getFriends(string username1);
        Friend delete(Friend friend);

        Friend sendFriendRequest(Friend friend);

        List<Friend> getFriendRequest(string username1);

        Friend agree(Friend friend);

    }
}