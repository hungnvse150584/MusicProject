using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class Sheet
    {
        [Key]
        public int SheetID { get; set; }

        public string Author { get; set; }

        public int SongID { get; set; }
        public int TimeSignatureID { get; set; }
        public int KeySignatureID { get; set; }

        public Song Song { get; set; } = null!;
        public TimeSignature TimeSignature { get; set; } = null!;
        public KeySignature KeySignature { get; set; } = null!;
    }
}
