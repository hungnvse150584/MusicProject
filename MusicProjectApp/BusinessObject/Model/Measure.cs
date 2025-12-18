using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class Measure
    {
        [Key]
        public int MeasureID { get; set; }

        public int SongID { get; set; }
        public Song Song { get; set; } = null!;
        
        public int MeasureNumber { get; set; }

        public ICollection<Beat> Beats { get; set; }
        public ICollection<Note> Notes { get; set; } 
        public ICollection<Rest> Rests { get; set; }
    }
}
