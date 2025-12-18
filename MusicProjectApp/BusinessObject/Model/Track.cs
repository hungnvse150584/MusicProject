using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class Track
    {
        [Key]
        public int TrackID { get; set; }

        public int SongID { get; set; }
        public Song Song { get; set; } = null!;

        public int ClefID { get; set; }
        public Clef Clef { get; set; }
    }
}
