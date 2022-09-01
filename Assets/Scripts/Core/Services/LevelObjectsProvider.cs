using UnityEngine;

namespace Core.Services
{
    public class LevelObjectsProvider
    {
        private Factory _factory;
        private PoolObjects _pool;

        public LevelObjectsProvider()
        {
            _factory = new Factory();
            _pool = new PoolObjects();
        }
        

    }
}