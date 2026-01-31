using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessObject.Enums.MusicNotationEnums;

namespace BusinessObject.Model
{
    public class MusicalEvent
    {
        [Key]
        public int EventID { get; set; }
        public int MeasureID { get; set; }
        public Measure Measure { get; set; } = null!;
        public float StartBeat { get; set; }  // Vị trí bắt đầu trong ô nhịp (tính bằng phách, có thể là số thập phân)
        public float DurationInBeats { get; set; } // Độ dài (tính bằng phách, có thể là số thập phân)
        public bool IsRest { get; set; } // true nếu là nốt nghỉ

        // Nếu là note/chord
        public bool IsChord { get; set; } // true nếu là hợp âm
        public ICollection<NotePitch> Pitches { get; set; } = new List<NotePitch>();

        // Navigation to NoteType(s)
        public ICollection<NoteType> NoteTypes { get; set; } = new List<NoteType>();

        //Grace note
        public bool IsGraceNote { get; set; } // true nếu là nốt nhấn
        public float GraceDurationRatio { get; set; } // Tỷ lệ độ dài nốt nhấn so với nốt chính

        public NoteTypeName BaseNoteType { get; set; }   // ← đây (Quarter, Eighth...)
        public int DotCount { get; set; } = 0;           // chấm đơn = 1, chấm đôi = 2...

        //Tuplet( liên kết nhiều event)
        public int? TupletID { get; set; }
        public TupletGroup? Tuplet { get; set; }
    }

}
