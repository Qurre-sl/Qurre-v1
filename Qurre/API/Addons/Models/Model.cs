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
        public readonly List<ModelBody> Body = new();
        public readonly List<ModelBot> Bots = new();
        public readonly List<ModelDoor> Doors = new();
        public readonly List<ModelGenerator> Generators = new();
        public readonly List<ModelLight> Lights = new();
        public readonly List<ModelLocker> Lockers = new();
        public readonly List<ModelPickup> Pickups = new();
        public readonly List<ModelPrimitive> Primitives = new();
        public readonly List<ModelTarget> Targets = new();
        public readonly List<ModelWorkStation> WorkStations = new();
        private readonly Dictionary<GameObject, ModelEnums> Parts = new();
        private static readonly List<Model> ModelsList = new();

        public void AddPart(ModelBody part, bool addToList = true)
        {
            if (addToList) Body.Add(part);
            Parts.Add(part.GameObject, ModelEnums.Body);
        }
        public void AddPart(ModelBot part, bool addToList = true)
        {
            if (addToList) Bots.Add(part);
            Parts.Add(part.GameObject, ModelEnums.Bot);
        }
        public void AddPart(ModelDoor part, bool addToList = true)
        {
            if (addToList) Doors.Add(part);
            Parts.Add(part.GameObject, ModelEnums.Door);
        }
        public void AddPart(ModelGenerator part, bool addToList = true)
        {
            if (addToList) Generators.Add(part);
            Parts.Add(part.GameObject, ModelEnums.Generator);
        }
        public void AddPart(ModelLight part, bool addToList = true)
        {
            if (addToList) Lights.Add(part);
            Parts.Add(part.GameObject, ModelEnums.Light);
        }
        public void AddPart(ModelLocker part, bool addToList = true)
        {
            if (addToList) Lockers.Add(part);
            Parts.Add(part.GameObject, ModelEnums.Locker);
        }
        public void AddPart(ModelPickup part, bool addToList = true)
        {
            if (addToList) Pickups.Add(part);
            Parts.Add(part.GameObject, ModelEnums.Pickup);
        }
        public void AddPart(ModelPrimitive part, bool addToList = true)
        {
            if (addToList) Primitives.Add(part);
            Parts.Add(part.GameObject, ModelEnums.Primitive);
        }
        public void AddPart(ModelTarget part, bool addToList = true)
        {
            if (addToList) Targets.Add(part);
            Parts.Add(part.GameObject, ModelEnums.Target);
        }
        public void AddPart(ModelWorkStation part, bool addToList = true)
        {
            if(addToList) WorkStations.Add(part);
            Parts.Add(part.GameObject, ModelEnums.WorkStation);
        }

        public Model(string id, Vector3 position, Vector3 rotation = default, Model root = null)
        {
            GameObject = new GameObject(id);
            GameObject.transform.parent = root?.GameObject?.transform;
            GameObject.transform.localPosition = position;
            GameObject.transform.localRotation = Quaternion.Euler(rotation);

            NetworkServer.Spawn(GameObject);

            ModelsList.Add(this);
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
            Body.Clear();
            Bots.Clear();
            Doors.Clear();
            Generators.Clear();
            Lights.Clear();
            Lockers.Clear();
            Pickups.Clear();
            Primitives.Clear();
            Targets.Clear();
            WorkStations.Clear();
        }

        internal static void ClearCache()
        {
            ModelsList.ForEach(model =>
            {
                try
                {
                    model.Parts.Clear();
                    model.Body.Clear();
                    model.Bots.Clear();
                    model.Doors.Clear();
                    model.Generators.Clear();
                    model.Lights.Clear();
                    model.Lockers.Clear();
                    model.Pickups.Clear();
                    model.Primitives.Clear();
                    model.Targets.Clear();
                    model.WorkStations.Clear();
                }
                catch { }
            });
            ModelsList.Clear();
        }
    }
}