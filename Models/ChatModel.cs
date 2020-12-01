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

    public class ChatHistory
    {
        public string message;
        public int userId;
        public DateTime sendingTime;
    }
}
