using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    /// <summary>
    /// Manage sets of <see cref="PoolableObject"/>'s pools. <br />
    /// Before retrieving the <see cref="PoolableObject"/>s, is neccesary to create the Pool <see cref="CreatePool(PoolableObject, int)"/> in the running scene. <br />
    /// Then, in order to get the next <see cref="PoolableObject"/>, use <see cref="GetNext(PoolableObject, Vector3, Quaternion, bool)"/>.
    /// </summary>
    public static class PoolManager
    {
        private static Dictionary<int, Stack<PoolableObject>> _Pools = new Dictionary<int, Stack<PoolableObject>>();

        private static readonly int _INITIAL_POOL_SIZE = 5;

        private static PoolableObject AddObjectToPool(PoolableObject prefab, int id)
        {
            var clone = GameObject.Instantiate(prefab);
            clone.gameObject.SetActive(false);
            clone.PoolID = id;
            _Pools[id].Push(clone);
            return clone;
        }

        public static void ReAddCloneToPool(PoolableObject clone)
        {
            int id = clone.PoolID;
            if (!_Pools.ContainsKey(id))
            {
                return;
            }

            _Pools[id].Push(clone);
        }

        public static void CreatePool(PoolableObject prefab, int poolSize)
        {
            var id = prefab.GetInstanceID();
            _Pools[id] = new Stack<PoolableObject>(poolSize);
            for (int i = 0; i < poolSize; i++)
            {
                AddObjectToPool(prefab, id);
            }
        }

        public static PoolableObject GetNext(PoolableObject prefab, Vector3 pos, Quaternion rot, bool active = true)
        {
            var clone = GetNext(prefab);
            clone.transform.position = pos;
            clone.transform.rotation = rot;
            clone.gameObject.SetActive(active);
            return clone;
        }

        private static PoolableObject GetNext(PoolableObject prefab)
        {
            var id = prefab.GetInstanceID();
            if (_Pools.ContainsKey(id) == false)
            {
                CreatePool(prefab, _INITIAL_POOL_SIZE);
            }

            if (_Pools[id].Count > 0)
            {
                return _Pools[id].Pop();
            }

            return AddObjectToPool(prefab, id);
        }
    }
}
