using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class Beat
    {
        [Key]
        public int BeatID { get; set; }

        public int MeasureID { get; set; }
        public Measure Measure { get; set; }

        public int BeatIndex { get; set; }   
    }
}
