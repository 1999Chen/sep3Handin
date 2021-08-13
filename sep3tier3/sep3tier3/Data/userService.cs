using System;
using System.Collections.Generic;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sep3tier3.DataAccess;
using sep3tier3.Models;


namespace sep3tier3.Data
{
    public class userService : IUserService
    {
        private string msgFile = "users.json";

        sepDBContext dbcontext;
        friendService _friendService;

        public userService()
        {
            dbcontext = new sepDBContext();
            _friendService = new friendService();
        }


        public User RegisterUser(User user)
        {
            if (dbcontext.Users.Any(x => x.username == user.username))
            {
                return null;
            }

            dbcontext.Users.Add(user);
            dbcontext.SaveChanges();
            return user;
        }

        public string LoginUser(string username, string password)
        {
            Console.WriteLine("loging userService");
            var existingUser = dbcontext.Users.SingleOrDefault(x => x.username == username);
            Console.WriteLine(existingUser);
            if (existingUser != null)
            {
                if (existingUser.password==password)
                {
                    return "T";
                }

                return "F";
            }

            return "F";
        }

        public void editInfo(User user)
        {
            var loginUser = dbcontext.Users.Find(user.username);
            loginUser.password = user.password;
            loginUser.firstname = user.firstname;
            loginUser.lastname = user.lastname;
            loginUser.sex = user.sex;
            loginUser.age = user.age;
            loginUser.major = user.major;
            loginUser.description = user.description;
            loginUser.hobbies = user.hobbies;
            loginUser.hometown = user.hometown;
            loginUser.birthday = user.birthday;
            // loginUser.birthday
            dbcontext.SaveChanges();
        }

        public List<User> getAllUsers()
        {
            var IEList = dbcontext.Users;
            var list = new List<User>();
            foreach (var user in IEList)
            {
                list.Add(user);
            }

            return list;
        }

        public User getUser(string username)
        {
            var users = getAllUsers();
            foreach (var user in users)
            {
                if (user.username == username)
                {
                    return user;
                }
            }

            return null;
        }

        public List<User> searchUsers(SearchUser searchUser)
        {
            List<User> users = getAllUsers();
            List<User> searchUsers = new List<User>();
            string username = searchUser.username;
            string firstname = searchUser.firstname;
            string lastname = searchUser.lastname;
            string sex = searchUser.sex;
            string major = searchUser.major;
            string hometown = searchUser.hometown;
            string hobbies = searchUser.hobbies;
            
            if (!String.IsNullOrEmpty(username))
            {
                foreach (User user in users)
                {
                    if (user.username == username)
                    {
                        searchUsers.Add(user);
                    }
                }

                users.Clear();
                foreach (var u in searchUsers)
                {
                    users.Add(u);
                }
                searchUsers.Clear();
            }
            if (!String.IsNullOrEmpty(firstname))
            {
                foreach (var user in users)
                {
                    if (user.firstname == firstname)
                    {
                        searchUsers.Add(user);
                    }
                }

                users.Clear();
                foreach (var u in searchUsers)
                {
                    users.Add(u);
                }
                searchUsers.Clear();
            }
            if (!String.IsNullOrEmpty(lastname))
            {
                foreach (var user in users)
                {
                    if (user.lastname == lastname)
                    {
                        searchUsers.Add(user);
                    }
                }
                users.Clear();
                foreach (var u in searchUsers)
                {
                    users.Add(u);
                }
                searchUsers.Clear();
            }
            if (!String.IsNullOrEmpty(sex))
            {
                foreach (var user in users)
                {
                    if (user.sex == sex)
                    {
                        searchUsers.Add(user);
                    }
                }

                users.Clear();
                foreach (var u in searchUsers)
                {
                    users.Add(u);
                }
                searchUsers.Clear();
            }
            if (!String.IsNullOrEmpty(major))
            {
                foreach (var user in users)
                {
                    if (user.major == major)
                    {
                        searchUsers.Add(user);
                    }
                }

                users.Clear();
                foreach (var u in searchUsers)
                {
                    users.Add(u);
                }
                searchUsers.Clear();
            }
            if (!String.IsNullOrEmpty(hometown))
            {
                foreach (var user in users)
                {
                    if (user.hometown == hometown)
                    {
                        searchUsers.Add(user);
                    }
                }

                users.Clear();
                foreach (var u in searchUsers)
                {
                    users.Add(u);
                }
                searchUsers.Clear();
            }
            if (!String.IsNullOrEmpty(hobbies))
            {
                foreach (var user in users)
                {
                    if (user.hobbies == hobbies)
                    {
                        searchUsers.Add(user);
                    }
                }

                users.Clear();
                foreach (var u in searchUsers)
                {
                    users.Add(u);
                }
                searchUsers.Clear();
            }


            return users;
        }

        public void storeMessage(ChatMessage chatMessage)
        {
            dbcontext.ChatMessages.Add(chatMessage);
        }

        public void addFriend(User user1, User user2)
        {
            Friend friend = new Friend
            {
                username1 = user1.username,
                username2 = user2.username,
                accept = false,
            };
            dbcontext.Friends.Add(friend);
            dbcontext.SaveChanges();
        }
    }
}