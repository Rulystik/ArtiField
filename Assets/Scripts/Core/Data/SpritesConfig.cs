using System;
using System.Collections.Generic;
using Core.Data;
using UnityEngine;

namespace Core.Data
{
    [CreateAssetMenu(fileName = "SpriteData", menuName = "Configs/SpriteConfig", order = 51), Serializable]
    public class SpritesConfig : ScriptableObject
    {
        [SerializeField] private List<Icons> _icons;
        private Dictionary<string , Sprite> _sprites;

        public void Init()
        {
            _sprites = new Dictionary<string, Sprite>();
            
            foreach (var icon in _icons)
            {
                if (_sprites.ContainsKey(icon.Name) == false)
                {
                    _sprites.Add(icon.Name, icon.Sprite);
                }
            }
        }

        public Sprite GetSprite(string name)
        {
            if (_sprites.ContainsKey(name))
            {
                return _sprites[name];
            }
        
            Debug.Log($"SpritesConfig - Wrong or non-existing name of sprite");
            return null;
        }
    }
}

