using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class Note
    {
        [Key]
        public int NoteID { get; set; }

        public int MeasureID { get; set; }
        public Measure Measure { get; set; } = null!;

        public string Pitch { get; set; }
        public int Octave { get; set; }

        [EnumDataType(typeof(Alter))]
        public Alter Alter { get; set; }

        public float Duration { get; set; }
        public float StartBeat { get; set; }

        public bool IsChord { get; set; }

        public ICollection<NoteType> NoteTypes { get; set; }
    }

    public enum Alter
    {
        flat = -1,
        natural = 0,
        sharp = 1,
    }
}
