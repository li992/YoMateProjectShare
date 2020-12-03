using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoMateProjectShare.Models
{
    public class ChatList
    {
        public int Id { get; set; }
        public List<ChatList> chatLists { get; set; }
    }
    public class Chatroom : ChatList
    {
        public List<ChatHistory> historyLists { get; set; }
    }

    public class roomAccessable
    {
        public int id { get; set; }
        public int chatroomId { get; set; }
        public string uid { get; set; }
        public DateTime joinedTime { get; set; }
    }

    public class ChatHistory
    {
        public int Id { get; set; }
        public int chatroomId { get; set; }
        public string message { get; set; }
        public int userId { get; set; }
        public DateTime sendingTime { get; set; }
    }
}
