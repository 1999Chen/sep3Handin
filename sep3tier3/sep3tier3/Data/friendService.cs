using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using sep3tier3.DataAccess;
using sep3tier3.Models;

namespace sep3tier3.Data
{
    public class friendService:IFriendService
    {
        sepDBContext dbcontext = new sepDBContext();
        private List<Friend> friends;

        public friendService()
        {
            this.friends = new List<Friend>();
        }


        public IEnumerable<Friend> getFriends()
        {
            return dbcontext.Friends;
            
        }
        
        
        
        
    }
}