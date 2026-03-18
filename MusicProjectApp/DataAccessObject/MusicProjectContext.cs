using BusinessObject.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class MusicProjectContext : IdentityDbContext<Account>
    {
        public MusicProjectContext() : base()
        { }
        public MusicProjectContext(DbContextOptions<MusicProjectContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<IdentityRole> roles = new List<IdentityRole>
               {
                   new IdentityRole
                   {
                       Id = "1",
                       Name = "Admin",
                       NormalizedName = "ADMIN",
                       ConcurrencyStamp = "1"
                   },
                   new IdentityRole
                   {
                       Id = "2",
                       Name = "Customer",
                       NormalizedName = "CUSTOMER",
                       ConcurrencyStamp = "2"
                   },
                   new IdentityRole
                   {
                       Id = "3",
                       Name = "Teacher",
                       NormalizedName = "TEACHER",
                       ConcurrencyStamp = "3"
                   },
                   new IdentityRole
                   {
                       Id = "4",
                       Name = "Staff",
                       NormalizedName = "STAFF",
                       ConcurrencyStamp = "4"
                   },
                   new IdentityRole
                   {
                       Id = "5",
                       Name = "Student",
                       NormalizedName = "STUDENT",
                       ConcurrencyStamp = "5"
                   }
              };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
            modelBuilder.Entity<Track>()
                .HasOne(t => t.Sheet)
                .WithMany(s => s.Tracks)
                .HasForeignKey(t => t.SheetID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Sheet>()
                .HasOne(s => s.Song)
                .WithMany(song => song.Sheets)
                .HasForeignKey(s => s.SongID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Instrument>()
                .HasOne(i => i.DefaultSound)
                .WithOne(s => s.DefaultInstrument)
                .HasForeignKey<Instrument>(i => i.DefaultSoundID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Sound>()
                .Property(s => s.Price)
                .HasPrecision(18, 4);  // 18 chữ số tổng, 4 chữ số thập phân (phù hợp giá tiền)

            modelBuilder.Entity<SoundPack>()
                .Property(sp => sp.Price)
                .HasPrecision(18, 4);

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Beat> Beats { get; set; }
        public DbSet<Clef> Clefs { get; set; }
        public DbSet<KeySignature> KeySignatures { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<MusicalEvent> MusicalEvents { get; set; }
        public DbSet<NoteType> NoteTypes { get; set; }
        public DbSet<NotePitch> NotePitches { get; set; }
        public DbSet<TupletGroup> TupletGroups { get; set; }
        public DbSet<NotationItem> NotationItems { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Sheet> Sheets { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<TimeSignature> TimeSignatures { get; set; }
        public DbSet<Track> Tracks { get; set; }
     	public DbSet<Sound> Sounds { get; set; }
	    public DbSet<SoundPack> SoundPacks { get; set; }
	    public DbSet<SoundPackItem> SoundPackItems { get; set; }
	    public DbSet<Instrument> Instruments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString(),
                    sqlOptions => sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                 .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "MusicProjectApp"))
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                 .Build();
            var strConn = config["ConnectionStrings:DbConnection"];

            return strConn;
        }
    }
}
