using csharp_social_networking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_social_networking
{
    class User
    {
        public string Username { get; }
        public List<User> FollowList { get; private set; }
        public List<Message> MessageList { get; private set; }

        public User (string name)
        {
            Username = name;
            FollowList = new List<User>();
            MessageList = new List<Message>();
        }

        public void postMessage(string postBody)
        {
            if (postBody != null || postBody != "")
            {
            MessageList.Add(new Message(postBody));
            }
        }

        public void followUser (User userToFollow)
        {
            if (!FollowList.Contains(userToFollow))
            {
            FollowList.Add(userToFollow);
            }
        }

        public void displayMessageList()
        {
            if (MessageList != null)
            {
                foreach (Message message in MessageList)
                {
                    Console.WriteLine($"    {message.MessageText} {message.Timestamp}");
                }
            }
        }
    }
}
