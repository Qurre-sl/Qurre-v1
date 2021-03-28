namespace Qurre.API.Controllers
{
    public static class Scp914
    {
        public static global::UnityEngine.GameObject GameObject { get; }
        public static bool Working { get; }
        public static global::Scp914.Scp914Knob KnobState { get; set; }
        public static global::Utils.ConfigHandler.ConfigEntry<global::Scp914.Scp914Mode> Cfg { get; set; }
        public static global::UnityEngine.Transform Intake { get; set; }
        public static global::UnityEngine.Transform Output { get; set; }
        public static List<Recipe> RecipesList { get; }

        public static void Activate();
        public static void Activate(float time);
        public static Dictionary<ItemType, Dictionary<global::Scp914.Scp914Knob, ItemType[]>> Recipes();
        public static void Recipes(Dictionary<ItemType, Dictionary<global::Scp914.Scp914Knob, ItemType[]>> recipes);
        public static int UpgradeItemID(int id);

        public class Recipe
        {
            public int itemID;
            public List<int> rough;
            public List<int> coarse;
            public List<int> oneToOne;
            public List<int> fine;
            public List<int> veryFine;

            public Recipe();
            public Recipe(global::Scp914.Scp914Recipe recipe);
        }
    }
}
