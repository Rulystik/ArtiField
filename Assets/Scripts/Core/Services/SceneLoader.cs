using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Services
{
    public class SceneLoader
    {
        private ICorutine _corutine;

        public SceneLoader(ICorutine corutine)
        {
            _corutine = corutine;
        }
        
        public void LoadScene (string name, Action action)
        {
            _corutine.StartCoroutine(Load(name, action));
        }
        
        private IEnumerator Load(string name, Action onLoaded)
        {
            AsyncOperation waiter = SceneManager.LoadSceneAsync(name);

            while (waiter.isDone == false)
            {
                yield return null;
            }
            
            onLoaded?.Invoke();
        }
        
        

    }
}