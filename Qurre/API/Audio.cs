using System.IO;
namespace Qurre.API
{
    public static class Audio
    {
        public static void Play(Stream stream, float volume);
        public static void PlayFromFile(string path, float volume);
        public static void PlayFromUrl(string url, float volume);
    }
}