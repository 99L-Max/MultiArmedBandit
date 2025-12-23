using System.IO;
using System.IO.Compression;
using System.Media;

namespace MultiArmedBandit
{
    static class Sound
    {
        public static void Play(byte[] buffer)
        {
            using (MemoryStream fileOut = new MemoryStream(buffer))
            using (GZipStream stream = new GZipStream(fileOut, CompressionMode.Decompress))
            using (SoundPlayer player = new SoundPlayer(stream))
                player.Play();
        }
    }
}