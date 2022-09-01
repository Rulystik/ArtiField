using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    [CreateAssetMenu(fileName = "ArtiPlacer", menuName = "Artiplacer/Default")]
    public class ArtiPlacerData : ScriptableObject, IPointerDownHandler
    {
        [SerializeField] public GameObject prefab;
        [SerializeField] private int ID;
        [SerializeField] private int count;
        private TextMesh text;
    
        public void Init()
        {
            text = prefab.transform.GetChild(0).GetComponent<TextMesh>();
            text.text = count.ToString();
        }
        public int GetIDArti {get => ID;}
        public int ArtiCount
        {
            get => count;
            set
            {
                count = value;
                text.text = count.ToString();
            }
        }

        public Action ArtiPlacerAction;
    
    
    

        public void OnPointerDown(PointerEventData eventData)
        {
            // var count = Convert.ToInt32(text.text);
            // if (count != 0)
            // {
            //     ArtiPlacerAction?.Invoke();
            // }
            Debug.Log(count);
        }
    }
}
