using UnityEngine;


namespace Core.Data
{
    [System.Serializable]
    public class Icons
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _sprite;
        
        public string Name
        {
            get => _name;
        }
        
        public Sprite Sprite
        {
            get => _sprite;
        }
    }
}