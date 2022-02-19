using System.Collections.Generic;
using System.Linq;
using Mirror;
using UnityEngine;
namespace Qurre.API.Addons.Textures
{
    /// <summary>
    ///  <para>Example:</para>
    ///  <para>var Model = new Model("Test", position, rotation);</para>
    ///  <para>Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cube, new Color32(0, 0, 0, 155), Vector3.zero, Vector3.zero, Vector3.one));</para>
    ///  <para>Model.AddPart(new ModelLight(Model, new Color(1, 0, 0), Vector3.zero, 1, 10));</para>
    /// </summary>
    public class Model
    {
        public readonly GameObject gameObject;
        private readonly Dictionary<GameObject, ModelEnums> Parts = new();

        public void AddPart(ModelPrimitive part) => Parts.Add(part.GameObject, ModelEnums.Primitive);
        public void AddPart(ModelLight part) => Parts.Add(part.GameObject, ModelEnums.Light);

        public Model(string id, Vector3 position, Vector3 rotation = default, Model root = null)
        {
            gameObject = new GameObject(id);
            gameObject.transform.parent = root?.gameObject?.transform;
            gameObject.transform.localPosition = position;
            gameObject.transform.localRotation = Quaternion.Euler(rotation);

            NetworkServer.Spawn(gameObject);
        }

        public void Destroy()
        {
            if (Parts.Count == 0) return;
            var _list = Parts.Select(x => x.Key).ToList();
            _list.ForEach(part =>
            {
                NetworkServer.UnSpawn(part);
                Object.Destroy(part);
            });
            Object.Destroy(gameObject);
            Parts.Clear();
        }
    }
}