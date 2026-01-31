using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Enums;
using static BusinessObject.Enums.MusicNotationEnums;

namespace BusinessObject.Model
{
    public class Instrument
    {
        [Key]
        public int InstrumentID { get; set; }

        public string Name { get; set; }

        public InstrumentType Type { get; set; } = InstrumentType.Unknown;

        // Default sound (sample) used by this instrument (optional)
        public int? DefaultSoundID { get; set; }
        public Sound? DefaultSound { get; set; }

        // If instrument is public (available to all) or private to owner
        public bool IsPublic { get; set; } = true;

        public string? OwnerAccountId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Friendly display name, e.g. "Acoustic Guitar (Nylon)"
        public string? DisplayName { get; set; }

        // Tracks can reference Instrument by InstrumentID (Track.InstrumentID)
        public ICollection<Track>? Tracks { get; set; }
    }
}
