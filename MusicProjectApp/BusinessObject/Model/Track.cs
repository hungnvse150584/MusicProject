using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessObject.Enums.MusicNotationEnums;

namespace BusinessObject.Model
{
    public class Track // Tay trái, phải
    {
        [Key]
        public int TrackID { get; set; }

        public int SheetID { get; set; }
        public Sheet Sheet { get; set; } = null!;
    

        // Clef reference (migration expects ClefID)
        public int ClefID { get; set; }
        public Clef Clef { get; set; } = null!;

        public int? InstrumentID { get; set; }     // MIDI program number hoặc custom instrument
        public string InstrumentName { get; set; } // "Piano (Right)", "Acoustic Guitar", "Drum Kit"...

        public ClefType ClefType { get; set; } = ClefType.G;

        public int? Transpose { get; set; }        // bán cung (cho trumpet, clarinet...)
        public bool IsTablature { get; set; }
    }
}
