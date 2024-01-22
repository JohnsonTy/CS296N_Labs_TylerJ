using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PineappleFanSite.Models
{
    [Table("Chats")]
    public class Messages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public AppUser Title { get; set; }
        public AppUser Topic { get; set; }
        public int Year { get; set; }
        public string Text { get; set; }
        public AppUser By { get; set; }
        public DateTime Date { get; set; }
    }
}
