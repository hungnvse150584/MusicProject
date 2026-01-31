using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Enums
{
    public class MusicNotationEnums
    {
        public enum InstrumentType
        {
            Unknown = 0,
            Piano = 1,
            Guitar = 2,
            Bass = 3,
            Drum = 4,
            Keyboard = 5,
            Strings = 6,
            Wind = 7,
            Percussion = 8,
            Synth = 9,
            Other = 99
        }

        public enum Alter
        {
            DoubleFlat = -2,
            Flat = -1,
            Natural = 0,
            Sharp = 1,
            DoubleSharp = 2
        }
        public enum NoteTypeName // dùng thay vì string để dễ kiểm soát
        {
            Whole, // tròn
            Half, // trắng
            Quarter, // đen
            Eighth, // móc đơn
            Sixteenth, // móc đôi
            ThirtySecond,
            SixtyFourth,
            // hỗ trợ tuplet sau
            // Grace note sẽ được xử lý riêng
        }
        public enum ArticulationType
        {
            None,
            Accent, // >
            Marcato, // ^
            Staccato, // chấm
            Staccatissimo,
            Tenuto, // -
            Fermata,
            BreathMark,
            Caesura,
            // ...
        }
        public enum DynamicMark
        {
            ppp, pp, p, mp, mf, f, ff, fff, ffff,
            fp, sf, sfz, sforzando, rfz, cresc, dim,
            // hairpins sẽ lưu riêng
        }
        public enum BarlineType
        {
            Regular,
            Double,
            Final,
            RepeatStart,
            RepeatEnd,
            Dashed,
            Short
        }
        public enum ClefType
        {
            G, // treble
            F, // bass
            C, // alto, tenor
            Percussion,
            TAB,
            TAB6, // guitar 6 dây
            TAB4 // bass 4 dây
        }
        public enum OrnamentType
        {
            Trill,
            Turn,
            Mordent,
            InvertedMordent,
            Appoggiatura,
            Acciaccatura,
            // ...
        }
    }
}
