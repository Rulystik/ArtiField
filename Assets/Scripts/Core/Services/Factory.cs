using UnityEngine;

namespace Core.Services
{
    public class Factory
    {
        private AssetProvider _assets;

        public Factory()
        {
            _assets = new AssetProvider();
        }
        
        public T GetGameObjectComponent<T>(Transform parent = null) where T: Component
        {
            var obj =  Object.Instantiate(_assets.GetPrefab<T>(), parent).GetComponent<T>();
            return obj;
        }
        public Sprite GetSprite (string name)
        {
           return _assets.GetSprite(name);
        }

    }
}