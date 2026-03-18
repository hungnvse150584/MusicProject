using AutoMapper;
using BusinessObject.Model;
using Service.RequestAndResponse.Response.Sheets;
using Service.RequestAndResponse.Response.KeySignatures;
using Service.RequestAndResponse.Response.TimeSignatures;
using Service.RequestAndResponse.Response.Accounts;
using Service.RequestAndResponse.Response.Clefs;
using Service.RequestAndResponse.Response.Measures;
using Service.RequestAndResponse.Response.Notes;
using Service.RequestAndResponse.Response.NoteTypes;
using Service.RequestAndResponse.Response.Beats;
using Service.RequestAndResponse.Response.Songs;
using Service.RequestAndResponse.Response.Rests;

namespace Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, GetAccountUser>().ReverseMap();
            CreateMap<Sheet, SheetResponse>();
            CreateMap<KeySignature, KeySignatureResponse>();
            CreateMap<TimeSignature, TimeSignatureResponse>();
            CreateMap<Clef, ClefResponse>();
            CreateMap<Measure, MeasureResponse>();

            CreateMap<MusicalEvent, NoteResponse>()
                .ForMember(dest => dest.NoteID, opt => opt.MapFrom(src => src.EventID))
                .ForMember(dest => dest.MeasureID, opt => opt.MapFrom(src => src.MeasureID))
                .ForMember(dest => dest.StartBeat, opt => opt.MapFrom(src => src.StartBeat))
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.DurationInBeats))
                .ForMember(dest => dest.IsChord, opt => opt.MapFrom(src => src.IsChord))
                .ForMember(dest => dest.Pitch, opt => opt.Ignore())
                .ForMember(dest => dest.Octave, opt => opt.Ignore())
                .ForMember(dest => dest.Alter, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    var first = src.Pitches?.FirstOrDefault();
                    if (first != null)
                    {
                        dest.Octave = first.Octave;
                        dest.Alter = (int)first.Alter;
                        dest.Pitch = first.Step switch { 0 => "C", 1 => "D", 2 => "E", 3 => "F", 4 => "G", 5 => "A", 6 => "B", _ => "C" };
                    }
                });

            CreateMap<NoteType, NoteTypeResponse>()
                .ForMember(dest => dest.NoteID, opt => opt.MapFrom(src => src.EventID));

            CreateMap<Beat, BeatResponse>();
            CreateMap<Song, SongResponse>();
            CreateMap<Sound, Sound>();
            CreateMap<SoundPack, SoundPack>();
            CreateMap<SoundPackItem, SoundPackItem>();
            CreateMap<Instrument, Instrument>();
        }
    }
}