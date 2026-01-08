using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.IRepositories;
using Repository.Repositories;
using Service.IService;
using Service.Mapping;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class ConfigureService
    {
        public static IServiceCollection ConfigureServiceService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IAccountService, AccountService>();
            
            services.AddScoped<IVnPayService, VnPayService>();
            
            services.AddScoped<ITokenService, TokenService>();

            // register sheet service and repository
            services.AddScoped<ISheetService, SheetService>();
            services.AddScoped<ISheetRepository, SheetRepository>();

            // register keysignature and timesignature services and repositories
            services.AddScoped<IKeySignatureService, KeySignatureService>();
            services.AddScoped<IKeySignatureRepository, KeySignatureRepository>();

            services.AddScoped<ITimeSignatureService, TimeSignatureService>();
            services.AddScoped<ITimeSignatureRepository, TimeSignatureRepository>();

            // register remaining services and repositories
            services.AddScoped<IClefService, ClefService>();
            services.AddScoped<IClefRepository, ClefRepository>();

            services.AddScoped<IMeasureService, MeasureService>();
            services.AddScoped<IMeasureRepository, MeasureRepository>();

            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<INoteRepository, NoteRepository>();

            services.AddScoped<INoteTypeService, NoteTypeService>();
            services.AddScoped<INoteTypeRepository, NoteTypeRepository>();

            services.AddScoped<IBeatService, BeatService>();
            services.AddScoped<IBeatRepository, BeatRepository>();

            services.AddScoped<ISongService, SongService>();
            services.AddScoped<ISongRepository, SongRepository>();

            services.AddScoped<IRestService, RestService>();
            services.AddScoped<IRestRepository, RestRepository>();

            return services;
        }
    }
}
