using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessObject.Enums.MusicNotationEnums;

namespace BusinessObject.Model
{
    public class NotationItem
    {
        [Key]
        public int NotationID { get; set; }
        public int MeasureID { get; set; }
        public Measure Measure { get; set; } = null!;
        public float StartBeat { get; set; }  // Vị trí bắt đầu trong ô nhịp (tính bằng phách, có thể là số thập phân)
        public float? EndBeat { get; set; }   // Vị trí kết thúc trong ô nhịp (nếu áp dụng, tính bằng phách, có thể là số thập phân)

        public ArticulationType? Articulation { get; set; }

        public DynamicMark? Dynamic { get; set; }
        public bool? IsHairpinStart { get; set; }
        public bool? IsHairpinEnd { get; set; }
        public DynamicMark? HairpinType { get; set; }

        public bool IsCrescendo { get; set; } // true nếu là dấu tăng dần (<)
        public bool IsDiminuendo { get; set; } // true nếu là dấu giảm dần (>)
        public OrnamentType? Ornament { get; set; }

        public string Text { get; set; } // Chữ viết thêm (lyrics, chord symbol, expression, technique...)
        public bool IsLyric { get; set; } // true nếu là lời bài hát
        public bool IsStaffText { get; set; } // true nếu là chữ viết trên khuông nhạc (không phải lời bài hát)

        //Pedal
        public bool IsSustainPedal { get; set; } // true nếu là pedal damper
        public bool PedalStart { get; set; } // true nếu là bắt đầu pedal
        public bool PedalEnd { get; set; } // true nếu là kết thúc pedal
    }
}
