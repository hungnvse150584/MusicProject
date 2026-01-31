using BusinessObject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessObject.Enums.MusicNotationEnums;

namespace BusinessObject.Model
{
    public class NotePitch
    {
        [Key]
        public int NotePitchID { get; set; }
        public int MusicalEventID { get; set; }
        public MusicalEvent MusicalEvent { get; set; }

        public int Step { get; set; }          // 0 = C, 1 = D, ..., 11 = B
        public int Octave { get; set; }        // octave khoa học (C4 = middle C)

        public Alter Alter { get; set; } = Alter.Natural;  // ← dùng enum này

        // Dành cho TAB guitar/bass
        public int? StringNumber { get; set; }
        public int? Fret { get; set; }

    }
    
}
