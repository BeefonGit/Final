// See https://aka.ms/new-console-template for more information
using System;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

class Program{static void Main(string[] args)
{
    Drums drums = new();
    drums.SetBass("Drums/Bass.mp3");
    drums.SetHihat("Drums/Hat.mp3");
    drums.SetSnare("Drums/Snare.wav");
    async Task PlayCymbalHitsAsync()
    {
        for (int i = 0; i < 16; i++)
        {
            drums.PlaySounds(drums.GetHihat());
            await Task.Delay(500); 
        }
    }
    // Call this method to start playing the cymbal hits asynchronously
    Task.Run(PlayCymbalHitsAsync);
}}