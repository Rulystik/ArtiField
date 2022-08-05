
using UnityEngine;
using UnityEngine.UI;

public class GameTile : MonoBehaviour
{
    private GameObject stateTileObj;
    private RectTransform rect;
    
    public int Id { get; private set; }

    public void Init(int id)
    {
        Id = id;
        gameObject.name = "Tile " + id;
        rect = gameObject.GetComponent<RectTransform>();
        stateTileObj = transform.GetChild(0).gameObject;
        
        DeactivateStateTile();
    }

    public void ActivateStateTile()
    {
        stateTileObj.SetActive(true);
    }

    public void DeactivateStateTile()
    {
        stateTileObj.SetActive(false);
    }

    public void SetStateIcon(Sprite sprite)
    {
        ActivateStateTile();
        stateTileObj.GetComponent<Image>().sprite = sprite;
    }
    public void SetPosition(Vector2 pos)
    {
        rect.anchoredPosition = pos;
    }
    public void SetScale(float scale)
    {
        rect.localScale = new Vector3(scale, scale, 0);
    }
}
