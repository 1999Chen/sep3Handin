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
        private string msgFile = "msgs.json";
        private List<User> users;
        sepDBContext dbcontext = new sepDBContext();
        friendService _friendService = new friendService();

        public userService()
        {
            string content = File.ReadAllText(msgFile);
            users = JsonSerializer.Deserialize<List<User>>(content);
        }

        private void WriteToFile()
        {
            string productsAsJson = JsonSerializer.Serialize(users);
            File.WriteAllText(msgFile, productsAsJson);
        }

        public User RegisterUser(User user)
        {
            if (dbcontext.Users.Any(x => x.username == user.username))
            {
                return null;
            }

            dbcontext.Users.Add(user);
            users.Add(user);
            dbcontext.SaveChanges();
            WriteToFile();
            return user;
        }

        public User LoginUser(User user)
        {
            var existingUser = dbcontext.Users.SingleOrDefault(x => x.username == user.username);

            if (existingUser != null)
            {
                if (existingUser.password.Equals(user.password))
                {
                    return user;
                }

                return null;
            }

            return null;
        }

        public void editInfo(User user, string firstname, string lastname, string sex, string description, string major,
            string hometown, byte[] profilePicture, int age, string hobbies)
        {
            var loginUser = dbcontext.Users.Find(user.username);
            loginUser.firstname = firstname;
            loginUser.lastname = lastname;
            loginUser.sex = sex;
            loginUser.age = age;
            loginUser.major = major;
            loginUser.description = description;
            loginUser.hobbies = hobbies;
            loginUser.hometown = hometown;
            loginUser.profilePicture = profilePicture;
            dbcontext.SaveChanges();
        }

        public IEnumerable<User> getAllUsers()
        {
            return dbcontext.Users;
        }

        public List<User> getUsersByInfo(string firstname, string lastname, string sex, string description,
            string major, string hometown, int maxage, int minage, string hobbies)
        {
            var users = getAllUsers();

            List<User> list = new List<User>();

            foreach (User user in users)
            {
                if (user.firstname.Contains(firstname) && user.lastname.Contains(lastname) && user.sex.Contains(sex) &&
                    user.description.Contains(description) && user.age >= minage && user.age <= maxage &&
                    user.hobbies.Contains(hobbies) && user.major.Contains(major) && user.hometown.Contains(hometown))
                {
                    list.Add(user);
                }
            }

            return list;
        }

        // public string addFriendRequest()
        // {
        //     
        //     
        //     
        // }
        //


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


        public List<Friend> getAllFriends(User user)
        {
            var friends = _friendService.getFriends();

            List<Friend> list = new List<Friend>();

            foreach (var friend in friends)
            {
                if (friend.username1.Equals(user.username) || friend.username2.Equals(user.username))
                {
                    list.Add(friend);
                }
            }

            return list;
        }
    }
}