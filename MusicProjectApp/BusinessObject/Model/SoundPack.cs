using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class SoundPack
    {
        [Key]
        public int SoundPackID { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        // If true, users must purchase to access contained sounds
        public bool IsPaid { get; set; }

        public decimal? Price { get; set; }

        public bool IsPublished { get; set; }

        public string? OwnerAccountId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation: items linking to Sounds
        public ICollection<SoundPackItem> Items { get; set; } = new List<SoundPackItem>();
    }
}
