using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class KeySignature
    {
        [Key]
        public int KeySignatureID { get; set; }

        public string KeyName { get; set; }

        public string Mode { get; set; }

        public int AccidentalCount { get; set; }

        public ICollection<Sheet> Sheets { get; set; }
    }
}
