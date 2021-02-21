namespace Qurre.API
{
    public class Scp914
    {
        public static bool IsWorking { get; }

        public static global::Utils.ConfigHandler.ConfigEntry<global::Scp914.Scp914Mode> Cfg();
        public static void Cfg(global::Utils.ConfigHandler.ConfigEntry<global::Scp914.Scp914Mode> config);
        public static global::UnityEngine.Transform Intake();
        public static void KnobState(global::Scp914.Scp914Knob scp914Knob);
        public static global::Scp914.Scp914Knob KnobState();
        public static global::UnityEngine.Transform Output();
        public static System.Collections.Generic.Dictionary<ItemType, System.Collections.Generic.Dictionary<global::Scp914.Scp914Knob, ItemType[]>> Recipes();
        public static void Recipes(System.Collections.Generic.Dictionary<ItemType, System.Collections.Generic.Dictionary<global::Scp914.Scp914Knob, ItemType[]>> recipes);
        public static void Start();
    }
}