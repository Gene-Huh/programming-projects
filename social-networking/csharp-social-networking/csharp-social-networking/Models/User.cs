using csharp_social_networking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_social_networking
{
    public class User
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

        public List<string> getUserMessages()
        {
            List<string> messages = new List<string>();
            if (MessageList != null && MessageList.Count >0)
            {
                foreach (Message message in MessageList)
                {
                    messages.Add(message.MessageText + " " + TimeFormatter.TimeAgo(message.Timestamp));
                }
            }
            return messages;
        }
    }
}
