namespace Qurre.API.Controllers
{
    public class Scp914
    {
        public global::UnityEngine.GameObject GameObject { get; }
        public bool Working { get; }
        public global::Scp914.Scp914Knob KnobState { get; set; }
        public global::Utils.ConfigHandler.ConfigEntry<global::Scp914.Scp914Mode> Cfg { get; set; }
        public global::UnityEngine.Transform Intake { get; set; }
        public global::UnityEngine.Transform Output { get; set; }
        public List<Recipe> RecipesList { get; }

        public void Activate();
        public void Activate(float time);
        public Dictionary<ItemType, Dictionary<global::Scp914.Scp914Knob, ItemType[]>> Recipes();
        public void Recipes(Dictionary<ItemType, Dictionary<global::Scp914.Scp914Knob, ItemType[]>> recipes);
        public int UpgradeItemID(int id);

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
