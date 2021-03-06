﻿using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_social_networking.Models
{
    [Serializable]
    public class Message
    {
        public string MessageText { get; }
        public DateTime Timestamp { get; }

        public Message(string text)
        {
            MessageText = text;
            Timestamp = DateTime.UtcNow;
        }

        public Message(string text, DateTime timestamp)
        {
            MessageText = text;
            Timestamp = timestamp;
        }
    }
}
