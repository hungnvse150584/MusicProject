using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessObject.Enums.MusicNotationEnums;

namespace BusinessObject.Model
{
    public class Sound
    {
        [Key]
        public int SoundID { get; set; }

        public string Name { get; set; }

        // URL or storage key (Cloudinary, blob, etc.)
        public string ProviderUrl { get; set; }

        // MIME type or file format (e.g. audio/wav, audio/mpeg)
        public string Format { get; set; }

        public int? SampleRate { get; set; }    // Hz
        public int? Channels { get; set; }      // 1 = mono, 2 = stereo
        public long? SizeBytes { get; set; }

        // Instrument type classification (optional)
        public InstrumentType InstrumentType { get; set; }

        // Premium / paid content
        public bool IsPremium { get; set; }
        public decimal? Price { get; set; }

        // Owner (account) who uploaded or published the sound (optional)
        public string? OwnerAccountId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public int? DefaultInstrumentID { get; set; }
        public Instrument? DefaultInstrument { get; set; }

        public ICollection<SoundPackItem> SoundPackItems { get; set; } = new List<SoundPackItem>();
    }
}
