using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class TimeSignature
    {

        [Key]
        public int TimeSignatureID { get; set; }

        public int BeatsPerMeasure { get; set; }

        public int BeatUnit { get; set; }

        public ICollection<Sheet> Sheets { get; set; }
    }
}
