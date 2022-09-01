using Core.Data;
using UnityEngine;

namespace Core.Services
{
    public class AssetProvider
    {
        private SpritesConfig _spritesConfig;
        private PrefabsConfig _prefabsConfigs;

        public AssetProvider()
        {
            _spritesConfig = Resources.Load<SpritesConfig>("SpritesConfig");
            _spritesConfig.Init();
            _prefabsConfigs = Resources.Load<PrefabsConfig>("PrefabsConfig");
            _prefabsConfigs.Init();
        }
        
        public Sprite GetSprite(string name) => _spritesConfig.GetSprite(name);

        public GameObject GetPrefab<T>() where T : Component => _prefabsConfigs.GetPrefab<T>();
    }
}