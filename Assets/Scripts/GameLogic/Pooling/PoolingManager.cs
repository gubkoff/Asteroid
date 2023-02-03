using Asteroid.GameLogic.Core;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid.GameLogic.Pooling
{
    public class PoolingManager : IPoolingManager
    {
        private readonly Transform _rootTransform;
        private readonly List<PoolItem> _poolItems;

        private Dictionary<ObjectType, Transform> _poolContainers;
        private Dictionary<ObjectType, List<GameObject>> _objectsPoolByType;

        public PoolingManager(List<PoolItem> poolItems, Transform rootTransform)
        {
            _poolItems = poolItems;
            _rootTransform = rootTransform;
        }

        public void PreparePool()
        {
            PrepareContainers();
            PrepareObjects();
        }

        public GameObject GetObjectByType(ObjectType type)
        {
            if (_objectsPoolByType.ContainsKey(type))
            {
                if (HasFreeObject(type, out GameObject obj))
                {
                    return obj;
                }
                else
                {
                    obj = CreateObject(type);
                    GetPoolByType(type).Add(obj);
                    return obj;
                }
            }

            return null;
        }

        private List<GameObject> GetPoolByType(ObjectType type)
        {
            return _objectsPoolByType[type];
        }

        private bool HasFreeObject(ObjectType type, out GameObject obj)
        {
            obj = null;
            var list = GetPoolByType(type);
            for (int i = 0; i < list.Count; i++)
            {
                if (!list[i].activeInHierarchy)
                {
                    obj = list[i];
                    return true;
                }
            }

            return false;
        }

        private void PrepareObjects()
        {
            _objectsPoolByType = new Dictionary<ObjectType, List<GameObject>>();
            foreach (var item in _poolItems)
            {
                if (_poolContainers.ContainsKey(item.Type))
                {
                    List<GameObject> itemList = new List<GameObject>();
                    for (int i = 0; i < item.Size; i++)
                    {
                        itemList.Add(CreateObject(item.Type));
                    }

                    _objectsPoolByType.Add(item.Type, itemList);
                }
            }
        }

        private GameObject GetPrefabByType(ObjectType type)
        {
            foreach (var item in _poolItems)
            {
                if (item.Type.Equals(type))
                {
                    return item.Prefab;
                }
            }

            return null;
        }

        private GameObject CreateObject(ObjectType type)
        {
            var itemPrefab = GameObject.Instantiate(GetPrefabByType(type), _poolContainers[type].position,
                Quaternion.identity);
            itemPrefab.transform.SetParent(_poolContainers[type], false);
            itemPrefab.SetActive(false);
            return itemPrefab;
        }

        private void PrepareContainers()
        {
            _poolContainers = new Dictionary<ObjectType, Transform>();
            foreach (var item in _poolItems)
            {
                if (!_poolContainers.ContainsKey(item.Type))
                {
                    var poolContainer = new GameObject($"{item.Type}_container").transform;
                    poolContainer.transform.position = Vector3.zero;
                    poolContainer.transform.rotation = Quaternion.identity;
                    poolContainer.transform.parent = _rootTransform;
                    _poolContainers.Add(item.Type, poolContainer);
                }
            }
        }
    }
}
       