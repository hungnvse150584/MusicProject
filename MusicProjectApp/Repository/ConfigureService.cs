using BusinessObject.Model;
using DataAccessObject;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.BaseRepository;
using Repository.IBaseRepository;
using Repository.IRepositories;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class ConfigureService
    {
        public static IServiceCollection ConfigureRepositoryService(this IServiceCollection services, IConfiguration configuration)
        {
            //
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IBeatRepository, BeatRepository>();
            services.AddScoped<IBeatRepository, BeatRepository>();
            services.AddScoped<IClefRepository, ClefRepository>();
            services.AddScoped<IKeySignatureRepository, KeySignatureRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<INoteTypeRepository, NoteTypeRepository>();
            services.AddScoped<IRestRepository, RestRepository>();
            services.AddScoped<ISheetRepository, SheetRepository>();
            services.AddScoped<ISongRepository, SongRepository>();
            services.AddScoped<ITimeSignatureRepository, TimeSignatureRepository>();
            services.AddScoped<ITrackRepository, TrackRepository>();
            services.AddScoped<INotePitchRepository, NotePitchRepository>();
            services.AddScoped<INotationItemRepository, NotationItemRepository>();
            services.AddScoped<ITupletGroupRepository, TupletGroupRepository>();
            services.AddScoped<IMusicalEventRepository, MusicalEventRepository>();
            services.AddScoped<ISoundRepository, SoundRepository>();
            services.AddScoped<ISoundPackItemRepository, SoundPackItemRepository>();
            services.AddScoped<ISoundPackRepository, SoundPackRepository>();
            services.AddScoped<IInstrumentRepository, InstrumentRepository>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            
            services.AddScoped<AccountDAO>();
            services.AddScoped<BeatDAO>();
            services.AddScoped<ClefDAO>();
            services.AddScoped<KeySignatureDAO>();
            services.AddScoped<MeasureDAO>();
            services.AddScoped<NoteDAO>();
            services.AddScoped<NoteTypeDAO>();
            services.AddScoped<RestDAO>();
            services.AddScoped<SheetDAO>();
            services.AddScoped<SongDAO>();
            services.AddScoped<TimeSignatureDAO>();
            services.AddScoped<TrackDAO>();
            services.AddScoped<NotePitchDAO>();
            services.AddScoped<NotationItemDAO>();
            services.AddScoped<TupletGroupDAO>();
            services.AddScoped<MusicalEventDAO>();
            services.AddScoped<SoundDAO>();
            services.AddScoped<SoundPackItemDAO>();
            services.AddScoped<SoundPackDAO>();
            services.AddScoped<InstrumentDAO>();
            //

            return services;
        }
    }
}
