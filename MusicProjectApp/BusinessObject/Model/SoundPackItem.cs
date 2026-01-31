using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class SoundPackItem
    {
        [Key]
        public int SoundPackItemID { get; set; }

        public int SoundPackID { get; set; }
        public SoundPack SoundPack { get; set; } = null!;

        public int SoundID { get; set; }
        public Sound Sound { get; set; } = null!;
    }
}
