using NAudio.Wave;
using NAudio.Wave.SampleProviders;

public class RhythmInstrument : Instrument
{
    private Dictionary<string, string> _ChordProgressions = new Dictionary<string, string>(); //A dictionary of common chord progressions to generate music off of

    public WaveStream GenerateChords(string Progression, string Key){}
}