using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_social_networking.Models
{
    public class WallEntry
    {
        public string WallName { get; }
        public Message WallMessage { get; }

        public WallEntry(string name, Message msg)
        {
            WallName = name;
            WallMessage = msg;
        }
    }
}
