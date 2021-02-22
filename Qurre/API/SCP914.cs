namespace Qurre.API
{
    public class Scp914
    {
        public static bool IsWorking { get; }
        public static global::Scp914.Scp914Knob KnobState { get; set; }
        public static global::Utils.ConfigHandler.ConfigEntry<global::Scp914.Scp914Mode> Cfg { get; set; }
        public static global::UnityEngine.Transform Intake { get; }
        public static global::UnityEngine.Transform Output { get; }

        public static void Activate();
        public static void Activate(float time);
        public static System.Collections.Generic.Dictionary<ItemType, System.Collections.Generic.Dictionary<global::Scp914.Scp914Knob, ItemType[]>> Recipes();
        public static void Recipes(System.Collections.Generic.Dictionary<ItemType, System.Collections.Generic.Dictionary<global::Scp914.Scp914Knob, ItemType[]>> recipes);
    }
}