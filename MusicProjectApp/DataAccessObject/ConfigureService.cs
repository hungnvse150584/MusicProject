using BusinessObject.Model;
using DataAccessObject.BaseDAO;
using DataAccessObject.IBaseDAO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public static class ConfigureService
    {
        public static IServiceCollection ConfigureDataAccessObjectService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<Account>();
            services.AddScoped<Beat>();
            services.AddScoped<Clef>();
            services.AddScoped<KeySignature>();
            services.AddScoped<Measure>();
            services.AddScoped<Note>();
            services.AddScoped<NoteType>();
            services.AddScoped<Rest>();
            services.AddScoped<Sheet>();
            services.AddScoped<Song>();
            services.AddScoped<TimeSignature>();
            services.AddScoped<Track>();
            services.AddScoped<RefreshToken>();
            
            services.AddScoped(typeof(IBaseDAO<>), typeof(BaseDAO<>));
            return services;
        }
    }
}
