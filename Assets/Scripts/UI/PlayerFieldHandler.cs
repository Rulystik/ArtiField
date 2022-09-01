using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace UI
{
    public class PlayerFieldHandler : MonoBehaviour
    {
        [SerializeField] private GameObject Panel;
        [SerializeField] private List<GameObject> PlacerPrefabs;
        [SerializeField] private BattleFieldView battleFieldView;
        [SerializeField] private Button rotateButton;

        private bool canRotate;
        private int posID;

        private Color normal;
        private Color red = Color.red;
        private Color green = Color.green;
    
        private List<Placer> placersList;

        private void Start()
        {
            canRotate = false;
            rotateButton.onClick.AddListener(Rotate);
            placersList = new List<Placer>();
        
            for (int i = 0; i < PlacerPrefabs.Count; i++)
            {
                var obj = Instantiate(PlacerPrefabs[i], Panel.transform).GetComponent<Placer>();
                obj.PlacerAction += PrePlaceArtillery;
                placersList.Add(obj);
            }

        }

        private void PrePlaceArtillery(Placer placer)
        {
            posID = GetRandomPos();
            normal = battleFieldView.playerViewObjects[posID].GetComponent<Image>().color;

        }
        private int GetRandomPos()
        {
            int x = Random.Range(0, GameSettings.Instance.WidthField);
            int y = Random.Range(0, GameSettings.Instance.HeightField);

            return x == 0 ? y : x * 100 + y;
        }
        private void Rotate()
        {
            battleFieldView.playerViewObjects[posID].GetComponent<Image>().color = normal;
        }
    }
}
