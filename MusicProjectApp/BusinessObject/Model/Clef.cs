using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class Clef
    {
        [Key]
        public int ClefID { get; set; }

        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}
