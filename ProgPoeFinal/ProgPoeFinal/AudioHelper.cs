using System;
using System.Media;

static class AudioHelper
{
    public static void PlayWelcomeMessage()
    {
        try
        {
            string soundPath = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "POE recording.wav"
            );
            using (var player = new SoundPlayer(soundPath))
            {
                player.PlaySync();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error playing sound: {ex.Message}");
        }
    }
}