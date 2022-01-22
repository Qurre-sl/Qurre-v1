namespace Qurre.API.Controllers
{
    public class Cassie
    {
        public readonly System.Collections.Generic.List<global::Subtitles.SubtitlePart> Subtitles;
        public string Message;
        public bool Hold;
        public bool Noise;

        public Cassie(string message, bool makeHold, bool makeNoise);
        public Cassie(string message, bool makeHold, bool makeNoise, System.Collections.Generic.List<global::Subtitles.SubtitlePart> subtitles);

        public static bool Lock { get; set; }
        public bool Active { get; }

        public static void Send(string msg, bool makeHold = false, bool makeNoise = false, bool instant = false, System.Collections.Generic.List<global::Subtitles.SubtitlePart> subtitles = null);
        public static void Send(string msg, System.Collections.Generic.List<global::Subtitles.SubtitlePart> subtitles, bool makeHold = false, bool makeNoise = false, bool instant = false);
        public void Send();
    }
}