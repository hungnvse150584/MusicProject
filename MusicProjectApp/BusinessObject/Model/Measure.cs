using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessObject.Enums.MusicNotationEnums;

namespace BusinessObject.Model
{
    public class Measure // Ô nhịp
    {
        [Key]
        public int MeasureID { get; set; }

        public int SongID { get; set; }
        public Song Song { get; set; } = null!;

        public int MeasureNumber { get; set; }           // số ô nhịp (1,2,3...)
        public int? TimeSignatureID { get; set; } // có thể thay đổi ở mỗi ô
        public TimeSignature? TimeSignature { get; set; }

        public ICollection<Beat> Beats { get; set; } = new List<Beat>();
        public ICollection<MusicalEvent> Notes { get; set; } = new List<MusicalEvent>();
    
        public ICollection<NotationItem> Notations { get; set; } = new List<NotationItem>();
        public BarlineType EndBarline { get; set; } = BarlineType.Regular;
        public BarlineType RightBarline { get; set; } = BarlineType.Regular;  // ← barline kết thúc ô
        public BarlineType LeftBarline { get; set; } = BarlineType.Regular;   // hiếm dùng, nhưng có khi repeat start
    }
}
