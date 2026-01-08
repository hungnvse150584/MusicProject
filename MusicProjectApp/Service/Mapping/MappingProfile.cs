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
            CreateMap<Note, NoteResponse>();
            CreateMap<NoteType, NoteTypeResponse>();
            CreateMap<Beat, BeatResponse>();
            CreateMap<Song, SongResponse>();
            CreateMap<Rest, RestResponse>();
        }
    }
}