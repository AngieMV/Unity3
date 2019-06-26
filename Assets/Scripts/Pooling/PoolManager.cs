using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    public static class PoolManager
    {
        private static Dictionary<int, List<PoolableObject>> _Pools = new Dictionary<int, List<PoolableObject>>();
        private static Dictionary<int, int> _Indexes = new Dictionary<int, int>();
        private static readonly int _INITIAL_POOL_SIZE = 5;

        private static PoolableObject AddObjectToPool(PoolableObject prefab, int id)
        {
            var clone = GameObject.Instantiate(prefab);
            clone.gameObject.SetActive(false);
            _Pools[id].Add(clone);
            return clone;
        }

        public static void CreatePool(PoolableObject prefab, int poolSize)
        {
            var id = prefab.GetInstanceID();
            _Pools[id] = new List<PoolableObject>(poolSize);
            _Indexes[id] = 0;
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

        public static PoolableObject GetNext(PoolableObject prefab)
        {
            var id = prefab.GetInstanceID();
            if (_Pools.ContainsKey(id) == false)
            {
                CreatePool(prefab, _INITIAL_POOL_SIZE);
            }

            for (int i = 0; i < _Pools[id].Count; i++)
            {
                _Indexes[id] = (_Indexes[id] + 1) % _Pools[id].Count;
                if (_Pools[id][_Indexes[id]].gameObject.activeInHierarchy == false)
                {
                    return _Pools[id][_Indexes[id]];
                }
            }

            return AddObjectToPool(prefab, id);
        }
    }
}
