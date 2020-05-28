using csharp_social_networking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_social_networking
{
    [Serializable]
    public class User
    {
        public string Username { get; }
        public List<User> FollowList { get; private set; }
        public List<Message> MessageList { get; private set; }

        public User(string name)
        {
            Username = name;
            FollowList = new List<User>();
            MessageList = new List<Message>();
        }

        public string postMessage(string postBody)
        {
            string successMessage = $"{Username} POSTED {postBody}";
            string failMessage = $"{Username}'s message didn't quite take, perhaps it was empty.";

            if (postBody != null && postBody != "")
            {
                MessageList.Add(new Message(postBody));
                return successMessage;
            }
            else
            {
                return failMessage;
            }
        }

        public string followUser(User userToFollow)
        {
            string successMessage = $"{userToFollow.Username} successfully followed";
            string failMessage = $"Unable to follow {userToFollow.Username}";
            if (!FollowList.Contains(userToFollow))
            {
                FollowList.Add(userToFollow);
                return successMessage;
            }
            else
            {
                return failMessage;
            }
        }

        public List<string> getUserMessages()
        {
            List<string> messages = new List<string>();
            if (MessageList.Count > 0)
            {
                foreach (Message message in MessageList)
                {
                    messages.Add($"   {message.MessageText} {TimeFormatter.TimeAgo(message.Timestamp)}");
                }
            }
            else
            {
                messages.Add($"{Username} has not posted any messages");
            }
            return messages;
        }

        public List<string> getWall()
        {
            List<WallEntry> tempWall = new List<WallEntry>();
            List<string> stringList = new List<string>();

            if (MessageList.Count != 0 && MessageList != null)
            {
                foreach (Message msg in MessageList)
                {
                    tempWall.Add(new WallEntry(Username, msg));
                }
            }
            if (FollowList != null)
            {
                foreach (User user in FollowList)
                {
                    foreach (Message msg in user.MessageList)
                    {
                        tempWall.Add(new WallEntry(user.Username, msg));
                    }
                }
            }
            tempWall.Sort((a, b) => b.WallMessage.Timestamp.CompareTo(a.WallMessage.Timestamp));
            foreach (WallEntry entry in tempWall)
            {
                stringList.Add($"   {entry.WallName} - {entry.WallMessage.MessageText} {TimeFormatter.TimeAgo(entry.WallMessage.Timestamp)}");
            }
            return stringList;
        }
    }
}
