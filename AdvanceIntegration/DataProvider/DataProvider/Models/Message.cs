using System;

namespace DataProvider.Models
{
    public class Message
    {
        public long Id { get; set; }
        public string Body { get; set; }
        public DateTime DateInsertedUtc { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdatedUtc { get; set; } = DateTime.UtcNow;
    }
}
