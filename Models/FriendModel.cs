using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoMateProjectShare.Models
{
    public class FriendList
    {
        public int Id { get; set; }
        public string belongtoId { get; set; }
        public List<FriendList> friendLists { get; set; }
    }

    public class Friend : FriendList
    {
        public string friendId { get; set; }
        public string friendNickname { get; set; }
        public DateTime addingTime { get; set; } 
    }
}
