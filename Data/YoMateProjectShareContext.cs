using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using YoMateProjectShare.Models;

namespace YoMateProjectShare.Data
{
    public class YoMateProjectShareContext : DbContext
    {
        public YoMateProjectShareContext(DbContextOptions<YoMateProjectShareContext> options) : base(options)
        {

        }

        public DbSet<Projects> Projects { get; set; }
        public DbSet<FriendList> FriendLists { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<ChatHistory> ChatHistorys { get; set; }
        public DbSet<Chatroom> Chatrooms { get; set; }
        public DbSet<ChatList> ChatLists { get; set; }
    }
}
