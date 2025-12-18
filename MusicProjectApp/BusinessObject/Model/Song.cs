using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class Song
    {
        [Key]
        public int SongID { get; set; }

        [ForeignKey("AccountID")]
        public string AccountID { get; set; }
        public Account Account { get; set; }

        public string Name { get; set; }

        public string Composer { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<Sheet> Sheets { get; set; }

        public ICollection<Measure> Measures { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}
