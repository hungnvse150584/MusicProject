using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class NoteType
    {
        [Key]
        public int NoteTypeID { get; set; }

        public int NoteID { get; set; }
        public Note Note { get; set; } = null!;

        public string NoteTypeName { get; set; }

        public float Duration { get; set; }
    }
}
