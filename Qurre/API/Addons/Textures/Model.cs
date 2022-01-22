namespace Qurre.API.Addons.Textures
{
    /// <summary>
    ///  <para>Example:</para> 
    ///  <para>var Model = new Model("Test", position, rotation);</para> 
    ///  <para>Model.AddPart(new ModelPart(Model, PrimitiveType.Cube, new Color32(0, 0, 0, 155), Vector3.zero, Vector3.zero, Vector3.one));</para> 
    /// </summary>
    public class Model
    {
        public readonly global::UnityEngine.GameObject gameObject;

        public Model(string id, global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 rotation = null, Model root = null);

        public void AddPart(ModelPrimitive part);
        public void AddPart(ModelLight part);
        public void Destroy();
    }
}