using Core.Data;
using Core.Other;
using UnityEngine;

namespace Core.Services
{
    public class AssetProvider
    {
        private SpritesConfig _spritesConfig;
        private PrefabsConfig _prefabsConfigs;

        public AssetProvider()
        {
            _spritesConfig = Resources.Load<SpritesConfig>(Const.SpritesConfig);
            _spritesConfig.Init();
            _prefabsConfigs = Resources.Load<PrefabsConfig>(Const.PrefabsConfig);
            _prefabsConfigs.Init();
        }
        
        public Sprite GetSprite(string name) => _spritesConfig.GetSprite(name);

        public GameObject GetPrefab<T>() where T : Component => _prefabsConfigs.GetPrefab<T>();
    }
}