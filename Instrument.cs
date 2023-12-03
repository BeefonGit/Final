using NAudio.Wave;
using NAudio.Wave.SampleProviders;

public class Instrument
{
    private Dictionary<string, ISampleProvider> _notes = new Dictionary<string, ISampleProvider>(); 
    public void SetNotes(Dictionary<string, ISampleProvider> notes)
    {
        _notes = notes;
    }
    // public void SetNote()
    public Dictionary<string, ISampleProvider> GetNotes()
    {
        return _notes;
    }
    public ISampleProvider SemitoneUpShift(string note_file)
    {
            var semitone = Math.Pow(2, 1.0/12);
            var upOneTone = semitone * semitone;
            using WaveStream reader = new MediaFoundationReader(note_file);
            var pitch = new SmbPitchShiftingSampleProvider(reader.ToSampleProvider())
            {
                PitchFactor = (float)upOneTone
            };
        return pitch;            
    }
    public ISampleProvider SemitoneDownShift(string note_file)
    {
            var semitone = Math.Pow(2, 1.0/12);
            var upOneTone = semitone * semitone;
            var downOneTone = 1.0/upOneTone;
            using WaveStream reader = new MediaFoundationReader(note_file);
            var pitch = new SmbPitchShiftingSampleProvider(reader.ToSampleProvider())
            {
                PitchFactor = (float)downOneTone
            };
        return pitch;            
    }
    public Dictionary<string, ISampleProvider> GenerateScales(string note_file) // This DOES NOT WORK YET
    {
        Dictionary<string, ISampleProvider> Note_Dict = new();
        List<string> Notes = new() {"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B", "CU", "C#U", "DU", "D#U", "EU", "FU", "F#U", "GU", "G#U", "AU", "A#U", "BU"};
        List<string> LowNotes = new() {"Cd", "C#d", "Dd", "D#d", "Ed", "Fd", "F#d", "Gd", "G#d", "Ad", "A#d", "Bd", "CUd", "C#Ud2", "DUd", "D#Ud", "EUd", "FUd", "F#Ud", "GUd", "G#Ud", "AUd", "A#Ud", "BUd"};
        for(int i=24; i > 0; i--)
        {
            ISampleProvider NewTone = SemitoneDownShift(note_file);
            Note_Dict[LowNotes[24-i]] = NewTone;
        }
        for(int i=0; i < 24; i++)
        {
            ISampleProvider NewTone = SemitoneUpShift(note_file);
            Note_Dict[Notes[i+23]] = NewTone;
        }
        return Note_Dict;
    }
}