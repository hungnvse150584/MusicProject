using AutoMapper;
using BusinessObject.Model;
using DataAccessObject;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.IRepositories;
using Repository.Repositories;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Request.Sheets;
using Service.RequestAndResponse.Response.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using static BusinessObject.Enums.MusicNotationEnums;

namespace Service.Service
{
    public class SheetService : ISheetService
    {
        private readonly ISheetRepository _sheetRepository;
        private readonly ISongRepository _songRepository;
        private readonly IMeasureRepository _measureRepository;
        private readonly INoteRepository _noteRepository;
        private readonly IRestRepository _restRepository;
        private readonly IBeatRepository _beat_repository;
        private readonly INoteTypeRepository _noteTypeRepository;
        private readonly IKeySignatureRepository _keySignatureRepository;
        private readonly ITimeSignatureRepository _timeSignatureRepository;
        private readonly ITrackRepository _trackRepository;
        private readonly IClefRepository _clefRepository;
        private readonly IMusicalEventRepository _musicalEventRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SheetService> _logger;
        private readonly MusicProjectContext _dbContext;

        public SheetService(ISheetRepository sheetRepository,
            ISongRepository songRepository,
            IMeasureRepository measureRepository,
            INoteRepository noteRepository,
            IRestRepository restRepository,
            IBeatRepository beatRepository,
            INoteTypeRepository noteTypeRepository,
            IKeySignatureRepository keySignatureRepository,
            ITimeSignatureRepository timeSignatureRepository,
            ITrackRepository trackRepository,
            IClefRepository clefRepository,
            IMapper mapper,
            MusicProjectContext dbContext)
        {
            _sheetRepository = sheetRepository;
            _songRepository = songRepository;
            _measureRepository = measureRepository;
            _noteRepository = noteRepository;
            _restRepository = restRepository;
            _beat_repository = beatRepository;
            _noteTypeRepository = noteTypeRepository;
            _keySignatureRepository = keySignatureRepository;
            _timeSignatureRepository = timeSignatureRepository;
            _trackRepository = trackRepository;
            _clefRepository = clefRepository ?? throw new ArgumentNullException(nameof(clefRepository));
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<BaseResponse<IEnumerable<SheetResponse>>> GetAllAsync()
        {
            var sheets = await _sheetRepository.GetAllWithDetailsAsync();
            var data = sheets.Select(s => _mapper.Map<SheetResponse>(s));
            return new BaseResponse<IEnumerable<SheetResponse>>("Get All Success", StatusCodeEnum.OK_200, data);
        }

        public async Task<BaseResponse<SheetResponse>> GetByIdAsync(int id)
        {
            try
            {
                var sheet = await _sheetRepository.GetSheetByIdAsync(id);
                var data = _mapper.Map<SheetResponse>(sheet);
                return new BaseResponse<SheetResponse>("Get Success", StatusCodeEnum.OK_200, data);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<SheetResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
        }

        public async Task<BaseResponse<SheetResponse>> CreateAsync(CreateSheetRequest request)
        {
            var sheet = new Sheet
            {
                Author = request.Author,
                SongID = request.SongID,
                TimeSignatureID = request.TimeSignatureID,
                KeySignatureID = request.KeySignatureID
            };
            try
            {
                var created = await _sheetRepository.AddAsync(sheet);
                var data = _mapper.Map<SheetResponse>(created);
                return new BaseResponse<SheetResponse>("Create Success", StatusCodeEnum.Created_201, data);
            }
            catch (Exception ex)
            {
                return new BaseResponse<SheetResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<SheetResponse>> UpdateAsync(int id, UpdateSheetRequest request)
        {
            try
            {
                var existing = await _sheetRepository.GetByIdAsync(id);
                existing.Author = request.Author;
                existing.SongID = request.SongID;
                existing.TimeSignatureID = request.TimeSignatureID;
                existing.KeySignatureID = request.KeySignatureID;
                var updated = await _sheetRepository.UpdateAsync(existing);
                var data = _mapper.Map<SheetResponse>(updated);
                return new BaseResponse<SheetResponse>("Update Success", StatusCodeEnum.OK_200, data);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<SheetResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<SheetResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<SheetResponse>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _sheetRepository.GetByIdAsync(id);
                var deleted = await _sheetRepository.DeleteAsync(existing);
                var data = _mapper.Map<SheetResponse>(deleted);
                return new BaseResponse<SheetResponse>("Delete Success", StatusCodeEnum.OK_200, data);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<SheetResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<SheetResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<SheetResponse>> ImportMusicXmlAsync(IFormFile file, int songId, string? author)
        {
            if (file == null || file.Length == 0)
                return new BaseResponse<SheetResponse>("File is empty", StatusCodeEnum.BadRequest_400, null);

            // validate song exists
            try
            {
                var song = await _songRepository.GetSongByIdAsync(songId);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<SheetResponse>("Song not found", StatusCodeEnum.NotFound_404, null);
            }

            try
            {
                XDocument doc;
                string fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
                using var inputStream = file.OpenReadStream();

                if (fileExtension == ".mxl")
                {
                    using var zipArchive = new System.IO.Compression.ZipArchive(inputStream, System.IO.Compression.ZipArchiveMode.Read, leaveOpen: true);
                    var xmlEntry = zipArchive.Entries
                        .FirstOrDefault(e => e.FullName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase) ||
                                             e.FullName.EndsWith(".musicxml", StringComparison.OrdinalIgnoreCase));

                    if (xmlEntry == null)
                        return new BaseResponse<SheetResponse>("Không tìm thấy file XML bên trong .mxl", StatusCodeEnum.BadRequest_400, null);

                    using var entryStream = xmlEntry.Open();
                    using var reader = new StreamReader(entryStream, detectEncodingFromByteOrderMarks: true);
                    doc = XDocument.Load(reader);
                }
                else
                {
                    using var reader = new StreamReader(inputStream, detectEncodingFromByteOrderMarks: true);
                    doc = XDocument.Load(reader);
                }

                // Lấy namespace (thường rỗng hoặc http://www.musicxml.org/xsd/MusicXML)
                XNamespace ns = doc.Root?.GetDefaultNamespace() ?? XNamespace.None;

                var rootName = doc.Root?.Name.LocalName ?? "NO ROOT";
                var hasPart = doc.Descendants(ns + "part").Any();
                var partCount = doc.Descendants(ns + "part").Count();

                // XÓA DÒNG DEBUG NÀY ĐỂ CODE TIẾP TỤC
                // throw new Exception($"Debug: Root = {rootName}, Namespace = {ns.NamespaceName}, Has part? {hasPart}, Count = {partCount}");

                var parts = doc.Descendants(ns + "part").ToList();
                if (!parts.Any())
                    return new BaseResponse<SheetResponse>("No parts found in MusicXML", StatusCodeEnum.BadRequest_400, null);

                // Lấy divisions (global hoặc từ part đầu)
                int globalDivisions = 1;
                foreach (var p in parts)
                {
                    var firstAttr = p.Elements(ns + "measure")
                                    .Select(m => m.Element(ns + "attributes"))
                                    .FirstOrDefault(a => a != null);
                    var divEl = firstAttr?.Element(ns + "divisions");
                    if (divEl != null && int.TryParse(divEl.Value, out var d) && d > 0)
                    {
                        globalDivisions = d;
                        break;
                    }
                }

                // Thu thập measure numbers từ attribute "number"
                var parsedMeasureNumbers = new HashSet<int>();
                foreach (var p in parts)
                {
                    foreach (var m in p.Elements(ns + "measure"))
                    {
                        var a = m.Attribute("number");
                        if (a != null && int.TryParse(a.Value, out var v) && v > 0)
                            parsedMeasureNumbers.Add(v);
                    }
                }

                var existingMeasures = (await _measureRepository.GetAllWithDetailsAsync())
                    .Where(x => x.SongID == songId)
                    .Select(x => x.MeasureNumber)
                    .ToHashSet();

                if (existingMeasures.Overlaps(parsedMeasureNumbers))
                {
                    return new BaseResponse<SheetResponse>("Duplicate measures detected for this song", StatusCodeEnum.Conflict_409, null);
                }

                // Lấy key signature và time signature từ measure đầu tiên
                int sheetKeyFifths = 0;
                string sheetKeyMode = "major";
                int sheetBeats = 4, sheetBeatUnit = 4;

                var firstPart = parts.First();
                var firstMeasure = firstPart.Elements(ns + "measure").FirstOrDefault();
                var firstAttributes = firstMeasure?.Element(ns + "attributes");

                if (firstAttributes != null)
                {
                    var keyEl = firstAttributes.Element(ns + "key");
                    if (keyEl != null)
                    {
                        int.TryParse(keyEl.Element(ns + "fifths")?.Value, out sheetKeyFifths);
                        sheetKeyMode = keyEl.Element(ns + "mode")?.Value ?? sheetKeyMode;
                    }

                    var timeEl = firstAttributes.Element(ns + "time");
                    if (timeEl != null)
                    {
                        int.TryParse(timeEl.Element(ns + "beats")?.Value, out sheetBeats);
                        int.TryParse(timeEl.Element(ns + "beat-type")?.Value, out sheetBeatUnit);
                    }
                }

                await using var transaction = await _dbContext.Database.BeginTransactionAsync();
                try
                {
                    var keySig = await GetOrCreateKeySignatureAsync(sheetKeyFifths, sheetKeyMode);
                    var timeSig = await GetOrCreateTimeSignatureAsync(sheetBeats, sheetBeatUnit);

                    var sheet = new Sheet
                    {
                        Author = author ?? string.Empty,
                        Title = $"Imported from MusicXML - {DateTime.UtcNow:yyyy-MM-dd}",  // thêm Title nếu cần
                        SongID = songId,
                        KeySignatureID = keySig.KeySignatureID,
                        TimeSignatureID = timeSig.TimeSignatureID,
                        InitialTempoBPM = 120,                  // giá trị mặc định nếu không parse được
                        InitialTempoText = "Moderato"           // ← GÁN GIÁ TRỊ KHÔNG NULL ở đây
                    };

                    var createdSheet = await _sheetRepository.AddAsync(sheet);

                    var createdMeasures = new Dictionary<int, Measure>();
                    foreach (var measureNumber in parsedMeasureNumbers.OrderBy(x => x))
                    {
                        var measure = new Measure { SongID = songId, MeasureNumber = measureNumber };
                        var created = await _measureRepository.AddAsync(measure);
                        createdMeasures[measureNumber] = created;
                    }

                    // TODO: Tiếp tục parse note, rest, chord... từ <note> trong mỗi <measure>
                    // Hiện tại chỉ tạo Sheet + Measures, bạn cần mở rộng để parse đầy đủ

                    await transaction.CommitAsync();

                    var response = _mapper.Map<SheetResponse>(createdSheet);
                    return new BaseResponse<SheetResponse>("Import MusicXML success (basic metadata)", StatusCodeEnum.Created_201, response);
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<SheetResponse>(
                    $"Lỗi khi import MusicXML: {ex.Message}" +
                    (ex.InnerException != null ? $" | Chi tiết: {ex.InnerException.Message}" : ""),
                    StatusCodeEnum.InternalServerError_500,
                    null);
            }
        }

        public async Task<BaseResponse<SheetResponse>> ImportMidiAsync(IFormFile file, int songId, string? author)
        {
            // Kiểm tra file cơ bản
            if (file == null || file.Length == 0)
                return new BaseResponse<SheetResponse>("File rỗng hoặc không hợp lệ", StatusCodeEnum.BadRequest_400, null);

            if (!file.FileName.EndsWith(".mid", StringComparison.OrdinalIgnoreCase) &&
                !file.FileName.EndsWith(".midi", StringComparison.OrdinalIgnoreCase))
                return new BaseResponse<SheetResponse>("Chỉ hỗ trợ file .mid hoặc .midi", StatusCodeEnum.BadRequest_400, null);

            // Đọc stream an toàn
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0; // Reset vị trí

            byte[] buffer = memoryStream.ToArray();
            if (buffer.Length < 14) // MIDI header tối thiểu ~14 bytes ("MThd" + header)
                return new BaseResponse<SheetResponse>("File MIDI quá nhỏ hoặc hỏng", StatusCodeEnum.BadRequest_400, null);

            // Kiểm tra header MIDI thủ công ("MThd")
            if (buffer[0] != 77 || buffer[1] != 84 || buffer[2] != 104 || buffer[3] != 100) // MThd
                return new BaseResponse<SheetResponse>("Không phải file MIDI hợp lệ (header MThd không đúng)", StatusCodeEnum.BadRequest_400, null);

            // Bây giờ đọc MIDI
            MidiFile midiFile;
            try
            {
                memoryStream.Position = 0; // Reset lại trước khi đọc
                midiFile = MidiFile.Read(memoryStream);
            }
            catch (NotEnoughBytesException ex)
            {
                return new BaseResponse<SheetResponse>("File MIDI không hợp lệ hoặc bị hỏng: " + ex.Message, StatusCodeEnum.BadRequest_400, null);
            }
            catch (Exception ex)
            {
                // Log chi tiết
                _logger?.LogError(ex, "Lỗi đọc MIDI file: {FileName}", file.FileName);
                return new BaseResponse<SheetResponse>("Không thể đọc file MIDI: " + ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }

            // Kiểm tra có track và note không
            var trackChunks = midiFile.GetTrackChunks().ToList();
            if (!trackChunks.Any())
                return new BaseResponse<SheetResponse>("Không có track nào trong file MIDI", StatusCodeEnum.BadRequest_400, null);

            // Lấy divisions (ticks per quarter note)
            int divisions = 480;
            if (midiFile.TimeDivision is TicksPerQuarterNoteTimeDivision tq)
                divisions = tq.TicksPerQuarterNote;

            // Lấy time signature đầu tiên (hoặc mặc định 4/4)
            var firstTimeSig = midiFile.GetTrackChunks()
                .SelectMany(tc => tc.Events)
                .OfType<TimeSignatureEvent>()
                .FirstOrDefault();

            int beatsPerMeasure = firstTimeSig?.Numerator ?? 4;
            int beatUnit = firstTimeSig?.Denominator ?? 4;

            double ticksPerBeat = divisions * (4.0 / beatUnit);
            double ticksPerMeasure = ticksPerBeat * beatsPerMeasure;

            // Thu thập tất cả note
            var allNotes = new List<(Melanchall.DryWetMidi.Interaction.Note Note, int TrackIndex)>();
            for (int i = 0; i < trackChunks.Count; i++)
            {
                var notes = trackChunks[i].GetNotes().ToList();
                foreach (var note in notes)
                    allNotes.Add((note, i));
            }

            if (!allNotes.Any())
                return new BaseResponse<SheetResponse>("Không có nốt nhạc nào trong file MIDI", StatusCodeEnum.BadRequest_400, null);

            // Tính các measure number dự kiến
            var parsedMeasureNumbers = new HashSet<int>();
            foreach (var (note, _) in allNotes)
            {
                int measureNumber = (int)(note.Time / (long)Math.Max(1, (long)ticksPerMeasure)) + 1;
                parsedMeasureNumbers.Add(measureNumber);
            }

            // Kiểm tra trùng lặp measure với DB
            var existingMeasures = await _measureRepository.GetAllWithDetailsAsync();
            var existingForSong = existingMeasures.Where(m => m.SongID == songId).Select(m => m.MeasureNumber).ToHashSet();

            if (existingForSong.Overlaps(parsedMeasureNumbers))
                return new BaseResponse<SheetResponse>("Đã tồn tại measure trùng với file MIDI này. Vui lòng xóa measure cũ trước.", StatusCodeEnum.Conflict_409, null);

            // Bắt đầu transaction
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var keySig = await GetOrCreateKeySignatureAsync(0, "major"); // C major mặc định
                var timeSig = await GetOrCreateTimeSignatureAsync(beatsPerMeasure, beatUnit);
                var clef = await GetOrCreateClefAsync("G", "2"); // Treble clef (G clef trên dòng 2)

                // Tạo Sheet
                var sheet = new Sheet
                {
                    Author = author ?? "Imported from MIDI",
                    Title = $"MIDI Import - {DateTime.UtcNow:yyyy-MM-dd}",
                    SongID = songId,
                    KeySignatureID = keySig.KeySignatureID,
                    TimeSignatureID = timeSig.TimeSignatureID
                };
                var createdSheet = await _sheetRepository.AddAsync(sheet);

                // Tạo Measures
                var createdMeasures = new Dictionary<int, Measure>();
                foreach (var measureNumber in parsedMeasureNumbers.OrderBy(x => x))
                {
                    var measure = new Measure
                    {
                        SongID = songId,
                        MeasureNumber = measureNumber
                    };
                    var created = await _measureRepository.AddAsync(measure);
                    createdMeasures[measureNumber] = created;
                }

                // Xử lý từng track
                for (int trackIndex = 0; trackIndex < trackChunks.Count; trackIndex++)
                {
                    var track = new Track
                    {
                        SheetID = createdSheet.SheetID,
                        ClefID = clef.ClefID,
                        InstrumentName = $"Track {trackIndex + 1}",
                        ClefType = ClefType.G // Có thể detect sau
                    };
                    var createdTrack = await _trackRepository.AddAsync(track);

                    var notesInTrack = trackChunks[trackIndex].GetNotes().OrderBy(n => n.Time).ToList();

                    // Nhóm note theo thời điểm để xử lý chord
                    var groupedNotes = notesInTrack
                        .GroupBy(n => n.Time)
                        .OrderBy(g => g.Key);

                    foreach (var group in groupedNotes)
                    {
                        long startTick = group.Key;
                        var pitches = group.Select(n => CreateNotePitch(n.NoteNumber)).ToList();

                        int measureNumber = (int)(startTick / (long)Math.Max(1, (long)ticksPerMeasure)) + 1;
                        if (!createdMeasures.TryGetValue(measureNumber, out var measure))
                            continue;

                        double startBeat = (startTick % (long)Math.Max(1, (long)ticksPerMeasure)) / ticksPerBeat;

                        // Duration: lấy từ note đầu tiên trong nhóm (giả sử cùng duration trong chord)
                        double durationBeats = group.First().Length / (double)divisions;

                        var musicalEvent = new MusicalEvent
                        {
                            MeasureID = measure.MeasureID,
                            StartBeat = (float)startBeat,
                            DurationInBeats = (float)durationBeats,
                            IsChord = pitches.Count > 1,
                            Pitches = pitches,
                            BaseNoteType = NoteTypeName.Quarter, // Có thể tính chính xác hơn sau
                            DotCount = 0
                        };

                        await _musicalEventRepository.AddAsync(musicalEvent); // Giả sử bạn có repo này

                        // Tạo Beat nếu chưa có
                        int beatIndex = (int)Math.Floor(startBeat);
                        // Logic kiểm tra và add Beat nếu cần (tương tự code cũ)
                    }
                }

                await transaction.CommitAsync();

                var response = _mapper.Map<SheetResponse>(createdSheet);
                return new BaseResponse<SheetResponse>("Import MIDI thành công", StatusCodeEnum.Created_201, response);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger?.LogError(ex, "Import MIDI thất bại cho song {SongId}", songId);
                return new BaseResponse<SheetResponse>("Lỗi khi import MIDI: " + ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        // Helper: Tạo NotePitch từ MIDI note number
        private NotePitch CreateNotePitch(int midiNumber)
        {
            int octave = (midiNumber / 12) - 1;
            int noteIndex = midiNumber % 12;
            string[] noteNames = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
            string name = noteNames[noteIndex];
            int alter = name.Contains('#') ? 1 : 0;
            char letter = name[0];
            int step = letter switch
            {
                'C' => 0,
                'D' => 1,
                'E' => 2,
                'F' => 3,
                'G' => 4,
                'A' => 5,
                'B' => 6,
                _ => 0
            };

            return new NotePitch
            {
                Step = step,
                Octave = octave,
                Alter = (Alter)alter
            };
        }

        private async Task<KeySignature> GetOrCreateKeySignatureAsync(int fifths, string mode)
        {
            var all = await _keySignatureRepository.GetAllAsync();
            var exist = all.FirstOrDefault(k => k.AccidentalCount == fifths && string.Equals(k.Mode, mode, StringComparison.OrdinalIgnoreCase));
            if (exist != null) return exist;

            var keyName = MapFifthsToKeyName(fifths, mode);
            var ks = new KeySignature { KeyName = keyName, Mode = mode ?? "", AccidentalCount = fifths };
            return await _keySignatureRepository.AddAsync(ks);
        }

        private string MapFifthsToKeyName(int fifths, string mode)
        {
            var major = new Dictionary<int, string> 
            {
                {-7, "Cb"}, {-6, "Gb"}, {-5, "Db"}, {-4, "Ab"}, {-3, "Eb"}, {-2, "Bb"}, {-1, "F"}, {0, "C"}, {1, "G"}, {2, "D"}, {3, "A"}, {4, "E"}, {5, "B"}, {6, "F#"}, {7, "C#"}
            };
            var minor = new Dictionary<int, string>
            {
                {-7, "Abm"}, {-6, "Ebm"}, {-5, "Bbm"}, {-4, "Fm"}, {-3, "Cm"}, {-2, "Gm"}, {-1, "Dm"}, {0, "Am"}, {1, "Em"}, {2, "Bm"}, {3, "F#m"}, {4, "C#m"}, {5, "G#m"}, {6, "D#m"}, {7, "A#m"}
            };
            if (string.Equals(mode, "minor", StringComparison.OrdinalIgnoreCase))
            {
                if (minor.TryGetValue(fifths, out var name)) return name;
            }
            else
            {
                if (major.TryGetValue(fifths, out var name)) return name;
            }
            return (mode ?? "") + " " + fifths.ToString();
        }

        private async Task<BusinessObject.Model.TimeSignature> GetOrCreateTimeSignatureAsync(int beats, int beatUnit)
        {
            var all = await _timeSignatureRepository.GetAllAsync();
            var exist = all.FirstOrDefault(t => t.BeatsPerMeasure == beats && t.BeatUnit == beatUnit);
            if (exist != null) return exist;
            var ts = new BusinessObject.Model.TimeSignature { BeatsPerMeasure = beats, BeatUnit = beatUnit };
            return await _timeSignatureRepository.AddAsync(ts);
        }

        private async Task<Clef> GetOrCreateClefAsync(string sign, string line)
        {
            var all = await _clefRepository.GetAllAsync();
            var name = sign + (string.IsNullOrEmpty(line) ? "" : $" (line {line})");
            var exist = all.FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase) || string.Equals(c.Name, sign, StringComparison.OrdinalIgnoreCase));
            if (exist != null) return exist;
            var clef = new Clef { Name = name };
            return await _clefRepository.AddAsync(clef);
        }
    }
}
