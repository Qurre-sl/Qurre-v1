using System.Collections.Generic;
using System.Linq;
using Mirror;
using UnityEngine;
namespace Qurre.API.Addons.Models
{
    /// <summary>
    ///  <para>Example:</para>
    ///  <para>var Model = new Model("Test", position, rotation);</para>
    ///  <para>Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cube, new Color32(0, 0, 0, 155), Vector3.zero, Vector3.zero, Vector3.one));</para>
    ///  <para>Model.AddPart(new ModelLight(Model, new Color(1, 0, 0), Vector3.zero, 1, 10));</para>
    /// </summary>
    public class Model
    {
        public readonly GameObject GameObject;
        private readonly Dictionary<GameObject, ModelEnums> Parts = new();

        public void AddPart(ModelDoor part) => Parts.Add(part.GameObject, ModelEnums.Door);
        public void AddPart(ModelGenerator part) => Parts.Add(part.GameObject, ModelEnums.Generator);
        public void AddPart(ModelLight part) => Parts.Add(part.GameObject, ModelEnums.Light);
        public void AddPart(ModelLocker part) => Parts.Add(part.GameObject, ModelEnums.Locker);
        public void AddPart(ModelPrimitive part) => Parts.Add(part.GameObject, ModelEnums.Primitive);
        public void AddPart(ModelTarget part) => Parts.Add(part.GameObject, ModelEnums.Target);
        public void AddPart(ModelWorkStation part) => Parts.Add(part.GameObject, ModelEnums.WorkStation);

        public Model(string id, Vector3 position, Vector3 rotation = default, Model root = null)
        {
            GameObject = new GameObject(id);
            GameObject.transform.parent = root?.GameObject?.transform;
            GameObject.transform.localPosition = position;
            GameObject.transform.localRotation = Quaternion.Euler(rotation);

            NetworkServer.Spawn(GameObject);
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
            Object.Destroy(GameObject);
            Parts.Clear();
        }
    }
}