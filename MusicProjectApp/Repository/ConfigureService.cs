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

            //

            return services;
        }
    }
}
