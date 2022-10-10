using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Data
{
    [CreateAssetMenu(fileName = "ConfigComponentList", menuName = "Configs/ConfigComponentList", order = 51)]
    
    public class PrefabsConfig : ScriptableObject
    {
        [SerializeField] private List<Component> _prefabConfig;
        private Dictionary<Type , GameObject> _configGameObjects;

        public void Init()
        {
            _configGameObjects = new Dictionary<Type, GameObject>();
            foreach (var config in _prefabConfig)
            {
                var key = config.GetType();
                if (_configGameObjects.ContainsKey(key) == false)
                {
                    _configGameObjects.Add(key, config.gameObject);
                }
            }
        }
        public GameObject GetPrefab<T>() where T : Component
        {
            Type key = typeof(T);
            if (_configGameObjects.ContainsKey(key))
            {
                return _configGameObjects[key];
            }
            Debug.Log($"{name} - Wrong or non-existing Component");
            return null;
        }
    }
}