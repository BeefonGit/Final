using NAudio.Wave;
using NAudio.Wave.SampleProviders;

class Drums
{
    private WaveStream _bass;
    public void SetBass(string note_file)
    {
        using WaveStream reader = new MediaFoundationReader(note_file);
        _bass = reader;
    }
    public WaveStream GetBass()
    {
        return _bass;
    }
    private WaveStream _hihat;
    public void SetHihat(string note_file)
    {
        using WaveStream reader = new MediaFoundationReader(note_file);
        _hihat = reader;
    }
    public WaveStream GetHihat()
    {
        return _hihat;
    }
    private WaveStream _snare;
    public void SetSnare(string note_file)
    {
        using WaveStream reader = new MediaFoundationReader(note_file);
        _snare = reader;
    }
    public WaveStream GetSnare()
    {
        return _snare;
    }

public void PlaySounds(params WaveStream[] sounds)
    {
        List<WaveOutEvent> waveOuts = new List<WaveOutEvent>();

        foreach (var sound in sounds)
        {
            WaveOutEvent waveOut = new WaveOutEvent();
            var waveProvider = sound;
            waveOut.Init(waveProvider);
            waveOuts.Add(waveOut);
        }
        foreach(WaveOutEvent waveOut in waveOuts)
        {
            waveOut.Play();
        }

        foreach (WaveOutEvent waveOut in waveOuts)
        {
            while (waveOut.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(10);
            }
            waveOut.Dispose();
        }
        foreach(WaveStream sound in sounds)
        {
            sound.Position = 0;
        }
    }    
}