using System.IO;
using System.IO.Compression;
using System.Media;

namespace MultiArmedBandit
{
    static class Sound
    {
        public static void Play(byte[] buffer)
        {
            using (var fileOut = new MemoryStream(buffer))
            using (var gz = new GZipStream(fileOut, CompressionMode.Decompress))
            using (var player = new SoundPlayer(gz))
                player.Play();
        }
    }
}