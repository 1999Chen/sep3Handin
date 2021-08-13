using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using sep3tier3.DataAccess;
using sep3tier3.Models;

namespace sep3tier3.Data
{
    public class friendService : IFriendService
    {
        sepDBContext dbcontext = new sepDBContext();
        private List<Friend> friends;

        public friendService()
        {
            this.friends = new List<Friend>();
        }

        

        public List<Friend> getAllFriends()
        {
            var list1 = dbcontext.Friends;
            var list = new List<Friend>();
            foreach (var friend in list1)
            {
                list.Add(friend);
            }

            return list;
        }

        public List<Friend> getFriends(string username1)
        {
            var list = getAllFriends();
            var resultList = new List<Friend>();
            foreach (var f in list)
            {
                if (f.username1 == username1 || f.username2 == username1)
                {
                    resultList.Add(f);
                }
            }
          Console.WriteLine("tier3 friend service");
          return resultList;
        }

        public Friend delete(Friend friend)
        {
            Friend friend1 = new Friend()
            {
                accept = true,
                username1 = friend.username2,
                username2 = friend.username1
            };
            if (dbcontext.Friends.Contains(friend))
            {
                dbcontext.Friends.Remove(friend);
            }

            if (dbcontext.Friends.Contains(friend1))
            {
                dbcontext.Friends.Remove(friend1);
            }
            
            dbcontext.SaveChanges();
            return friend;
        }

        public Friend sendFriendRequest(Friend friend)
        {
            if (dbcontext.Friends.Contains(friend))
            {
                Console.WriteLine("Friend already added or waited!");
            }

            if (dbcontext.Users.Find(friend.username2)==null)
            {
                 Console.WriteLine("User not found!");
            }

            dbcontext.Friends.Add(friend);
            dbcontext.SaveChanges();
            return friend;

        }

        public List<Friend> getFriendRequest(string username1)
        {
            var list = getAllFriends();
            var result=new List<Friend>();
            foreach (var f in list)
            {
                if (f.accept.Equals(false) && f.username2.Equals(username1))
                {
                    result.Add(f);
                }
                
            }
            return result;
        }

        public Friend agree(Friend friend)
        {
            var f=dbcontext.Friends.Find(friend.username1, friend.username2);
            f.accept = true;
            dbcontext.SaveChanges();

            Console.WriteLine(dbcontext.Friends.Find(friend.username1,friend.username2).accept.ToString());
            return f;
        }
        
    }
}