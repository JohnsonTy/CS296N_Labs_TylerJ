using System.ComponentModel.DataAnnotations.Schema;

namespace PineappleFanSite.Models
{
    public class SEntry
    {
        // Other properties...

        [NotMapped] // Add this attribute
        public string Discriminator { get; set; }

        // Rest of your class...
    }
}
