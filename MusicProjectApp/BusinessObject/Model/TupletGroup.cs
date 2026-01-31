using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class TupletGroup
    {
        [Key]
        public int TupletID { get; set; }
        public int ActualNotes { get; set; }   // 3 trong triplet
        public int NormalNotes { get; set; }   // 2 (thay cho 3 nốt thường)
        public float? DurationMultiplier => (float)NormalNotes / ActualNotes;
    }
}
