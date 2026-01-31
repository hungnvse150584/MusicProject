using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class NoteType // Kiểu nốt: đen, móc đơn, đôi,...    
    {
        [Key]
        public int NoteTypeID { get; set; }

        // After merging Note into MusicalEvent, link to the event
        public int EventID { get; set; }
        public MusicalEvent MusicalEvent { get; set; } = null!;

        public string NoteTypeName { get; set; }

        public float Duration { get; set; }
    }
}
