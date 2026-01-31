using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Model
{
    public class Rest
    {
        [Key]
        public int RestID { get; set; }

        public int MeasureID { get; set; }
        public Measure Measure { get; set; } = null!;

        public float Duration { get; set; }
        public float StartBeat { get; set; }
    }
}