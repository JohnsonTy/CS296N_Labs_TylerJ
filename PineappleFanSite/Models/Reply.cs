using System.ComponentModel.DataAnnotations;

namespace PineappleFanSite.Models
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        public string SenderId { get; set; }

        public string Name { get; set; }

        public string ReplyBody { get; set; }

        public DateTime Date { get; set; }

        public int MessageId { get; set; }
    }
}